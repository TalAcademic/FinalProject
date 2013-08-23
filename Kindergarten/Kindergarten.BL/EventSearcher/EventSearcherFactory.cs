using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.EventSearcher
{
    public class EventSearcherFactory :ISearcherFactory
    {
        private static List<ISearcher> _availableSearchers;

        public static List<string> AvailableEventTypes { get; private set; }


        public EventSearcherFactory()
        {
            if (_availableSearchers == null)

                FillAvialableSearchers();
        }

        private void FillAvialableSearchers()
        {
            _availableSearchers=new List<ISearcher>();
            AvailableEventTypes= new List<string>();
            var fullLocation =Assembly.GetAssembly(GetType()).CodeBase;
            var toRemove =fullLocation.LastIndexOf('/');
            var location = fullLocation.Remove(toRemove);
            var u = new Uri(location);
            var files = Directory.GetFiles(u.AbsolutePath);
            var searchers = (from file in files
                                      where (file.ToLower().Contains("searcher") &&  file.ToLower().Contains(".dll"))
                                      select file).ToList();

            foreach (var searcher in searchers)
            {
                var ass = Assembly.LoadFile(searcher);
                var types = ass.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsClass&&type.IsPublic)
                    {
                        if (type.GetInterfaces().Contains(typeof(ISearcher)))
                        {
                            var o = (ISearcher)Activator.CreateInstance(type);
                            _availableSearchers.Add(o);
                            AvailableEventTypes.Add(o.EventGeneralName);
                        }
                    }
                }
            }
            

        }

        public ISearcher GetSearcher(string name)
        {
            var found = (from searcher in _availableSearchers
                                     where searcher.EventGeneralName == name
                                     select searcher).ToList();

            return found.Count==0 ? null : found[0];
        }

        public List<ISearcher> GetAllSearchers()
        {
            return _availableSearchers;
        }
    }

  

}
