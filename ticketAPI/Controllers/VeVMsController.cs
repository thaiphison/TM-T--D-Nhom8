using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ticketAPI.Repositories;
using ticketAPI.Entities;
using ticketAPI.Dtos;

namespace ticketAPI.Controllers
{
    //GET /VeVM
    [ApiController]
    [Route("veVMs")]
    public class VeVMsController : ControllerBase
    {
        private readonly IVeVMsRepository repository;

        public VeVMsController(IVeVMsRepository repository){
            this.repository = repository;
        }

        //GET /veVMs
        [HttpGet]
        public IEnumerable<VeVMDto> GetVeVMs(){
            var items = repository.GetVeVMs().Select( item => item.AsDto());
            return items;
        }

        //Get /veVMs/{maGhe}
        [HttpGet("{maGhe}")]
        public ActionResult<VeVMDto> GetVeVM(int maGhe){
            var item = repository.GetVeVM(maGhe);

            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }


        //Post /veVMs
        [HttpPost]
        public ActionResult<VeVMDto> CreateVeVM(CreateVeVMDto veVMDto){
            VeVM vevm = new(){
                maGhe = veVMDto.maGhe,
                giaVe = veVMDto.giaVe
            };

            repository.CreateVeVM(vevm);
            return CreatedAtAction(nameof(GetVeVM), new { maGhe = vevm.maGhe }, vevm.AsDto());
        }

        //Put /veVMs/{maGhe}
        [HttpPut("{maGhe}")]
        public ActionResult UpdateVeVM(int maGhe, UpdateVeVMDto veVMDto){
            var existingVeVM = repository.GetVeVM(maGhe);

            if(existingVeVM is null){
                return NotFound();
            }
            
            VeVM updatedVeVM = existingVeVM with {
                giaVe = veVMDto.giaVe
            };

            repository.UpdateVeVM(updatedVeVM);

            return NoContent();
        }

        //DELETE /veVMs/{maGhe}
        [HttpDelete("{maGhe}")]
        public ActionResult DeleteVeVM(int maGhe){
            var existingVeVM = repository.GetVeVM(maGhe);

            if(existingVeVM is null){
                return NotFound();
            }
            
            repository.DeleteVeVM(maGhe);

            return NoContent();
        }
    }
}