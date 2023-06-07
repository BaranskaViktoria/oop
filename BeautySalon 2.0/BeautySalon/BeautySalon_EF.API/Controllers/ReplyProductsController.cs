﻿using Microsoft.AspNetCore.Mvc;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace BeautySalon_EF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReplyProductsController : ControllerBase
    {
        private readonly ILogger<ReplyProductsController> _logger;

        private IUnitOfWork _ADOuow;
        public ReplyProductsController(ILogger<ReplyProductsController> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }
        [HttpGet]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow.ReplyProductsRepository.GetAsync();
                if (result == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }


    }
}
