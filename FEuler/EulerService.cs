using FEuler.Domain;
using FEuler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FEuler
{
    public class EulerService
    {
        Dictionary<int, Type> _options;
        string _optionText;

        public EulerService()
        {
            //List<IEuler> options = Assembly.GetExecutingAssembly()
            //    .GetReferencedAssemblies()
            //    .Select(x => Assembly.Load(x))
            //    .SelectMany(x => x.GetTypes()
            //        .Where(t => t.GetInterfaces().Contains(typeof(IEuler)) && t.GetConstructor(Type.EmptyTypes) != null)
            //        .Select(t => Activator.CreateInstance(t) as IEuler))
            //    .ToList();
            List<IEuler> options = typeof(Euler0).Assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IEuler)) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(t => Activator.CreateInstance(t) as IEuler)
                .ToList();
            
            _optionText = "";
            _options = new Dictionary<int, Type>();
            options.OrderBy(o => o.GetId());
            List<int> ids = new List<int>();
            foreach (IEuler item in options)
            {
                _options.Add(item.GetId(), item.GetType());
                ids.Add(item.GetId());
            }
            NumberListFormatter formatter = new NumberListFormatter(ids);

            _optionText = "Please select from the list of solved problems: \n" + formatter.Get() + "\n";
        }

        private void RunEuler(int id)
        {
            IEuler euler = null;
            Type type;
            _options.TryGetValue(id, out type);
            if (type != null)
            {
                euler = Activator.CreateInstance(type) as IEuler;
                if (euler != null)
                {
                    Console.WriteLine("");
                    euler.Summary();
                    euler.Run();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            Console.Clear();
        }

        public void Run()
        {
            Console.Write(_optionText);
            RunSelection();

        }

        private void RunSelection()
        {
            string s = Console.ReadLine();
            int i = 0;
            if (int.TryParse(s, out i))
            {
                RunEuler(i);
                Run();
            }
            else
            {
                Console.Clear();
                Run();
            }
        }
    }
}
