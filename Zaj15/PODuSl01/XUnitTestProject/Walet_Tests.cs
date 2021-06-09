using PODuSl01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class Walet_Tests
    {
        [Fact]
        public void BadTest()
        {
            using (var db = new PODuSl01.DbModels.BikeStoresContext())
            {
                var items = db.Brands.ToList();

                Assert.Contains(items, x=> x.BrandId > 0);

            }
        }


        [Fact]
        public void TakeMoney_Get300WithSaldo200_ThrowsEx()
        {
            var wallet = new Walet(200);

            Assert.Throws<InvalidOperationException>(
                () => wallet.TakeMoney(300)
                );
        }

        [Theory]
        [InlineData(200,300)]
        [InlineData(0, 100)]
        [InlineData(2000, 13000)]       
        public void TakeMoney_GetMoreThanSaldo_ThowsEx(decimal saldo, decimal takeMoney)
        {
            var wallet = new Walet(saldo);

            Assert.Throws<InvalidOperationException>(
                () => wallet.TakeMoney(takeMoney)
                );
        }

        [Theory]
        [InlineData(1110, 300)]
        [InlineData(11110, 100)]
        [InlineData(1112000, 13000)]
        public void TakeMoney_GetLessThanSaldo(decimal saldo, decimal takeMoney)
        {
            var wallet = new Walet(saldo);

            wallet.TakeMoney(takeMoney);
        }
    }
}
