using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UnityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IDataRepository, ADORepo>();

            IUnityContainer container = new UnityContainer().LoadConfiguration();          
            Logic logic = container.Resolve<Logic>();
            logic.Add();
            logic.Remove();
        }
    }


    public interface IDataRepository
    {
        void Create();
        void Read();
        void Update();
        void Delete();
    }
    public class ADORepo : IDataRepository
    {
        public void Create()
        {
            Console.WriteLine("ADORepo Create");
        }

        public void Read()
        {
            Console.WriteLine("ADORepo Read");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            Console.WriteLine("ADORepo Delete");
        }
    }

    public class EFRepo : IDataRepository
    {
        public void Create()
        {
            Console.WriteLine("EFRepo Create");
        }

        public void Read()
        {
            Console.WriteLine("EFRepo Read");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            Console.WriteLine("EFRepo Delete");
        }
    }

    public class Logic
    {
        private IDataRepository _repo;
        public Logic(IDataRepository repo)
        {
            _repo = repo;
        }

        public void Add()
        {
            _repo.Create();
        }

        public void Remove()
        {
            _repo.Delete();
        }
    }
}
