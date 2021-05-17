using ticketAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ticketAPI.Repositories
{
    
    public class InMemVeVMsRepository : IVeVMsRepository
    {
        private readonly List<VeVM> items = new()
        {
            new VeVM { maGhe = 1, giaVe = 50000 },
            new VeVM { maGhe = 2, giaVe = 50000 },
            new VeVM { maGhe = 3, giaVe = 50000 },
            new VeVM { maGhe = 4, giaVe = 50000 }
        };

        public IEnumerable<VeVM> GetVeVMs()
        {
            return items;
        }

        public VeVM GetVeVM(int maGhe)
        {
            return items.Where(item => item.maGhe == maGhe).SingleOrDefault();
        }

        public void CreateVeVM(VeVM vevm)
        {
            items.Add(vevm);
        }

        public void UpdateVeVM(VeVM vevm)
        {
            var index = items.FindIndex(existingVeVM => existingVeVM.maGhe == vevm.maGhe);
            items[index] = vevm;
        }

        public void DeleteVeVM(int maGhe)
        {
            var index = items.FindIndex(existingVeVM => existingVeVM.maGhe == maGhe);
            items.RemoveAt(index);
        }
    }
}