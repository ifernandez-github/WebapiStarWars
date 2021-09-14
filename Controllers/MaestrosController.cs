using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebapiMaestros.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebapiMaestros.Models;
using WebapiMaestros.Services.Interfaces;

namespace WebapiMaestros.Controllers
{

   /// <summary>
   /// Controlador que maneja lo relativo al ejército StarWars.
   /// </summary>
   [Route("api")]
   [ApiController]
   public class MaestrosController : Controller
   {
      private readonly ILogger<MaestrosController> _logger;
      private readonly IStarWarsService _starWarsService;
      
      public MaestrosController(ILogger<MaestrosController> logger, IStarWarsService starWarsService)
      {
         _logger = logger;
         _starWarsService = starWarsService;
      }

      // GET: api/armies
      /// <summary>
      /// Consulta todas las naves y sus armas de todos los ejercitos de la BBDD
      /// </summary>
      [HttpGet]
      [Route("armies")]
      public IActionResult GetArmies()
      {
         return Ok(_starWarsService.GetArmies());
      }

      // GET: api/ships
      /// <summary>
      /// Obtienen todas las naves 
      /// </summary>
      /// <param name="shipName">Nombre de la nave</param>
      [HttpGet]
      [Route("ships")]
      public IActionResult GetShips()
      {
         return Ok(_starWarsService.GetShips());
      }

      // GET: api/ships
      /// <summary>
      /// Obtienen todas las naves que contien en el nombre el texto enviado
      /// </summary>
      /// <param name="shipName">Nombre de la nave</param>
      [HttpGet]
      [Route("shipsbyname")]
      public IActionResult GetShipsByName(string shipName)
      {
         return Ok(_starWarsService.GetShipsByName(shipName));
      }

      // GET: api/ships
      /// <summary>
      /// Obtiene la nave del idShip enviado
      /// </summary>
      /// <param name="idShip">Nombre de la nave</param>
      [HttpGet]
      [Route("shipbyid")]
      public IActionResult GetShipsById(int idShip)
      {
         return Ok(_starWarsService.GetShipsById(idShip));
      }
   }
}
