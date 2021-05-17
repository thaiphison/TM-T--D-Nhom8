using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Repositories
{
    public interface IVeVMsRepository
    {
        VeVM GetVeVM(int maGhe);
        IEnumerable<VeVM> GetVeVMs();

        void CreateVeVM(VeVM vevm);

        void UpdateVeVM(VeVM vevm);

        void DeleteVeVM(int maGhe);
    }
}