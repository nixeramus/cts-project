using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD.CTS.Data;
using TD.CTS.MsSqlData;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MsSqlDataTests
{
    [TestClass]
    public class DataProviderTest
    {
        private IDataProvider provider = new MsSqlDataProvider("Data Source=.;Initial Catalog=CTSDB;UID=sa;PWD=admin");

        [TestMethod]
        public void RoleTest()
        {
            List<Role> list = provider.GetList<Role>(new RoleDataFilter());

            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void UserTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            int suffix = random.Next();
            User entity = new User()
            {
                Login = "test_" + suffix,
                Email = "test@domain.com",
                FullName = "Test user " + suffix,
                HospitalId = 1,
                Password = "123"
            };

            List<Role> roles = provider.GetList<Role>(new RoleDataFilter());
            Assert.IsTrue(roles.Count > 2);

            entity.Roles.Add(roles[0]);
            entity.Roles.Add(roles[1]);

            string updatedName = "Updaded " + entity.FullName;
            Role deletedRole = null;
            Role addedRole = roles[2];

            EntityTest<User>(entity, new UserDataFilter(),
                e => { return new UserDataFilter { Login = e.Login }; },
                e =>
                {
                    Assert.IsTrue(e.Roles.Count == 2);
                    e.FullName = updatedName;
                    deletedRole = e.Roles[1];
                    e.Roles.RemoveAt(1);
                    e.Roles.Add(addedRole);
                },
                e =>
                {
                    return updatedName.Equals(e.FullName)
                        && e.Roles.Any(r => r.Code == addedRole.Code)
                        && !e.Roles.Any(r => r.Code == deletedRole.Code);
                });
        }

        [TestMethod]
        public void CityTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            int suffix = random.Next();
            City entity = new City()
            {
                Name = "Test city " + suffix
            };

            string updatedName = "Updaded " + entity.Name;

            EntityTest<City>(entity, new CityDataFilter(),
                e => { return new CityDataFilter() { Id = e.Id }; },
                e => { e.Name = updatedName; },
                e => { return updatedName.Equals(e.Name); });
        }

        [TestMethod]
        public void HospitalTest()
        {
            City city = provider.GetItem<City>(new CityDataFilter());

            Assert.IsNotNull(city);

            var random = new Random(DateTime.Now.Millisecond);
            int suffix = random.Next();
            Hospital entity = new Hospital()
            {
                Name = "Test city " + suffix,
                CityId = city.Id
            };

            string updatedName = "Updaded " + entity.Name;

            EntityTest<Hospital>(entity, new HospitalDataFilter(),
                e => { return new HospitalDataFilter() { Id = e.Id }; },
                e => { e.Name = updatedName; },
                e => { return updatedName.Equals(e.Name); });
        }

        [TestMethod]
        public void ReferalTest()
        {
            Hospital hospital = provider.GetItem<Hospital>(new HospitalDataFilter());

            Assert.IsNotNull(hospital);

            var random = new Random(DateTime.Now.Millisecond);
            int suffix = random.Next();
            Referal entity = new Referal()
            {
                FullName = "Test referal " + suffix,
                HospitalId = hospital.Id,
                Email = "e@e.com",
                Phone = "777",
                WorkPlace = "home"
            };

            string updatedName = "Updaded " + entity.FullName;

            EntityTest<Referal>(entity, new ReferalDataFilter(),
                e => { return new ReferalDataFilter() { Id = e.Id }; },
                e => { e.FullName = updatedName; },
                e => { return updatedName.Equals(e.FullName); });

        }

        [TestMethod]
        public void PatientTest()
        {
            Hospital hospital = provider.GetItem<Hospital>(new HospitalDataFilter());

            Assert.IsNotNull(hospital);

            var random = new Random(DateTime.Now.Millisecond);
            int suffix = random.Next();
            Patient entity = new Patient()
            {
                FullName = "Test patient " + suffix,
                HospitalId = hospital.Id,
                Email = "e@e.com",
                Phone = "777",
                Address = "home",
                BirthDate = DateTime.Now.AddYears(-40),
                SourceType = "Прочее"
            };

            string updatedName = "Updaded " + entity.FullName;
            Referal referal = provider.GetItem<Referal>(new ReferalDataFilter());
            Assert.IsNotNull(referal);

            EntityTest<Patient>(entity, new PatientDataFilter(),
                e => { return new PatientDataFilter() { Id = e.Id }; },
                e => 
                {
                    e.FullName = updatedName;
                    e.SourceType = "Реферал";
                    e.ReferalId = referal.Id;
                },
                e => 
                { 
                    return updatedName.Equals(e.FullName)
                        && "Реферал".Equals(e.SourceType)
                        && e.ReferalId.HasValue && referal.Id == e.ReferalId.Value; 
                });

        }

        [TestMethod]
        public void ProcedureTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            int suffix = random.Next();
            Procedure entity = new Procedure()
            {
                Code = "TEST",
                Name = "Test procedure " + suffix
            };

            string updatedName = "Updaded " + entity.Name;

            EntityTest<Procedure>(entity, new ProcedureDataFilter(),
                e => { return new ProcedureDataFilter() { Code = e.Code }; },
                e => { e.Name = updatedName; },
                e => { return updatedName.Equals(e.Name); });
        }

        private void EntityTest<TEntity>(
            TEntity entity,
            DataFilter<TEntity> filter,
            Func<TEntity, DataFilter<TEntity>> getItemFilter,
            Action<TEntity> updateEntity,
            Func<TEntity, bool> testUpdate)
            where TEntity : Entity, new()
        {
            List<TEntity> list = provider.GetList<TEntity>(filter);

            Assert.AreNotEqual(0, list.Count);

            provider.Add(entity);

            var itemFilter = getItemFilter(entity);

            entity = provider.GetItem<TEntity>(itemFilter);

            Assert.IsNotNull(entity);

            updateEntity(entity);

            provider.Update(entity);

            entity = provider.GetItem<TEntity>(itemFilter);

            Assert.IsTrue(testUpdate(entity));

            provider.Delete(entity);

            entity = provider.GetItem<TEntity>(itemFilter);

            Assert.IsNull(entity);
        }

        [TestMethod]
        public void Test()
        {
            
        }
    }
}
