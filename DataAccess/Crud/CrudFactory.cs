using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;

        public abstract void Create(BaseEntity entityDTO);
        public abstract void Update(BaseEntity entityDTO);
        public abstract void Delete(BaseEntity entityDTO);
        public abstract List<T> RetrieveAll<T>();

        public abstract T RetrieveById<T>(int id);


    }
}
