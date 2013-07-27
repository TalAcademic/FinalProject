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
        private static List<string> _availableEventTypes;

        public static List<string> AvailableEventTypes
        {
            get { return _availableEventTypes; }
        }


        public EventSearcherFactory()
        {
            if (_availableSearchers == null)

                FillAvialableSearchers();
        }

        private void FillAvialableSearchers()
        {
            _availableSearchers=new List<ISearcher>();
            _availableEventTypes= new List<string>();
            string fullLocation =Assembly.GetAssembly(this.GetType()).CodeBase;
            int toRemove =fullLocation.LastIndexOf('/');
            string location = fullLocation.Remove(toRemove);
            Uri u = new Uri(location);
            string[] files = Directory.GetFiles(u.AbsolutePath);
            List<string> searchers = (from file in files
                                      where (file.ToLower().Contains("searcher") &&  file.ToLower().Contains(".dll"))
                                      select file).ToList();
            foreach (var searcher in searchers)
            {
                Assembly ass = Assembly.LoadFile(searcher);
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsClass&&type.IsPublic)
                    {
                        if (type.GetInterfaces().Contains(typeof(ISearcher)))
                        {
                            ISearcher o = (ISearcher)Activator.CreateInstance(type);
                            _availableSearchers.Add(o);
                            _availableEventTypes.Add(o.EventGeneralName);
                        }
                    }
                }
            }
            

        }

        public ISearcher GetSearcher(string name)
        {
            List<ISearcher> found = (from searcher in _availableSearchers
                                     where searcher.EventGeneralName == name
                                     select searcher).ToList();
            if (found.Count==0)
                return null;
            return found[0];
        }

        public List<ISearcher> GetAllSearchers()
        {
            return _availableSearchers;
        }
    }

    public interface ISearcherFactory
    {
        ISearcher GetSearcher(string name);
        List<ISearcher> GetAllSearchers();
    }

}
