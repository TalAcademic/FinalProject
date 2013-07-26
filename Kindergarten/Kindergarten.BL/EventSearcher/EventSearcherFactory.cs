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

        public EventSearcherFactory()
        {
            if (_availableSearchers == null)

                FillAvialableSearchers();
        }

        private void FillAvialableSearchers()
        {
            _availableSearchers=new List<ISearcher>();
            string fullLocation =Assembly.GetAssembly(this.GetType()).CodeBase;
            int toRemove =fullLocation.LastIndexOf('/');
            string location = fullLocation.Remove(toRemove);
            Uri u = new Uri(location);
            string[] files = Directory.GetFiles(u.AbsolutePath);
            List<string> searchers = (from file in files
                                      where file.ToLower().Contains("searcher")
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
                            Object o = Activator.CreateInstance(type);
                            _availableSearchers.Add((ISearcher)o);
                        }
                    }
                }
            }
            

        }

        public ISearcher GetSearcher(string name)
        {
            throw new NotImplementedException();
        }

        public List<ISearcher> GetAllSearchers()
        {
            throw new NotImplementedException();
        }
    }

    public interface ISearcherFactory
    {
        ISearcher GetSearcher(string name);
        List<ISearcher> GetAllSearchers();
    }

}
