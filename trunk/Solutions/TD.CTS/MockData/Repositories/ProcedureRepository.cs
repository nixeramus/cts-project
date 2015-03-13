using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.Common.Data;

namespace TD.CTS.MockData.Repositories
{
    class ProcedureRepository : Repository<Procedure>
    {
        public ProcedureRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {            
        }

        public override List<Procedure> GenerateData()
        {
            var list = new List<Procedure>();

            list.Add(new Procedure { Code = "ОВ", Name = "Обследование врачом" });
            list.Add(new Procedure { Code = "ЗВ", Name = "Звонок" });
            list.Add(new Procedure { Code = "ОАК", Name = "Общий анализ крови" });
            list.Add(new Procedure { Code = "АМ", Name = "Анализ мочи" });
            list.Add(new Procedure { Code = "АК", Name = "Клинический анализ крови" });
            list.Add(new Procedure { Code = "ФОГ", Name = "Флюорография" });
            list.Add(new Procedure { Code = "УЗИ", Name = "Ультразвуковое исследование" });
            list.Add(new Procedure { Code = "ЭКГ", Name = "Электрокардиография" });

            return list;
        }

        protected override Func<Procedure, bool> GetFilterFunc(DataFilter<Procedure> filter)
        {
            ProcedureDataFilter dataFilter = (ProcedureDataFilter)filter;

            return e =>
                (string.IsNullOrEmpty(dataFilter.Code) || e.Code == dataFilter.Code)
                && (string.IsNullOrEmpty(dataFilter.Name) || e.Name.Contains(dataFilter.Name));
        }

        protected override int GetItemIndex(Procedure item)
        {
            return Data.IndexOf(e => e.Code == item.Code);
        }

        protected override void SetNewValues(Procedure item)
        {
            if (string.IsNullOrEmpty(item.Code))
                throw new ApplicationException("Требуется код процедуры");
            int index = GetItemIndex(item);
            if (index > -1)
                throw new ApplicationException("Процедура с таким кодом уже есть");
        }
    }
}
