using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetManagementAPI.DTOs.VoucherDTOs;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vouchers = await _voucherService.GetAll();
            return Ok(vouchers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var voucher = await _voucherService.GetById(id);
            if (voucher == null)
            {
                return NotFound(new { message = "Voucher not found" });
            }

            return Ok(voucher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVoucherDTO voucherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voucher = await _voucherService.Create(voucherDTO);
            return Ok(voucher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVoucherDTO voucherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voucher = await _voucherService.Update(id, voucherDTO);
            if (voucher == null)
            {
                return NotFound(new { message = "Voucher not found" });
            }

            return Ok(voucher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var voucher = await _voucherService.Delete(id);
            if (voucher == null)
            {
                return NotFound(new { message = "Voucher not found" });
            }

            return Ok(voucher);
        }
    }
}
