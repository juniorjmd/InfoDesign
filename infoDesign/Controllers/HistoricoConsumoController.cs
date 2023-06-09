using infoDesign.AccesoDatos.Data.Repository.IRepository;
using infoDesign.AccesoDatos.Data;
using Microsoft.AspNetCore.Mvc;
using infoDesign.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using infoDesign.modelos;
using infoDesign.modelos.Dtos;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace infoDesign.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoConsumoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly MyDbContext _Context;

        public HistoricoConsumoController( IContenedorTrabajo contenedorTrabajo , MyDbContext Context )
        {
            _contenedorTrabajo = contenedorTrabajo;
            _Context = Context; 
        }
      


        [HttpGet( "[action]")]
        public IActionResult ConsumoPorUsuario([FromQuery] RangoDeFecha rango)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Expression<Func<vw_HistoricoConsumos, bool>> filter = h => h.fecha >= rango.fechaInicial && h.fecha >= rango.fechaFinal;
                    Func<IQueryable<vw_HistoricoConsumos>, IOrderedQueryable<vw_HistoricoConsumos>> orderBy = q => q.OrderBy(consumo => consumo.idTipCliente).ThenBy(consumo => consumo.fecha);
                    int limit = 1000;


                    List<vw_HistoricoConsumos> hist = _contenedorTrabajo.vwHistoricoConsumo.GetAll(filter, orderBy, null, limit).ToList();


                    return Ok(Json(_contenedorTrabajo.vwHistoricoConsumo.ObtenerHistoriaPorTipoUsuario(hist)));

                }
                return BadRequest("rango invalido");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        /**/

        [HttpGet("[action]")]
        public IActionResult ConsumoPorTramos([FromQuery] RangoDeFecha rango)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    Expression<Func<vw_HistoricoConsumos, bool>> filter = h => h.fecha >= rango.fechaInicial && h.fecha >= rango.fechaFinal;
                    Func<IQueryable<vw_HistoricoConsumos>, IOrderedQueryable<vw_HistoricoConsumos>> orderBy = q => q.OrderBy(consumo => consumo.idLinea).ThenBy(consumo => consumo.fecha);
                    int limit = 1000;


                    List<vw_HistoricoConsumos> hist =  _contenedorTrabajo.vwHistoricoConsumo.GetAll(filter, orderBy , null , limit).ToList();

                                                                                                                                                           
                    return Ok(Json(_contenedorTrabajo.vwHistoricoConsumo.ObtenerHistorialLineas(hist)));

                }
                return BadRequest("rango invalido");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }




        [HttpGet("[action]")]
        public IActionResult PeoresTramosPorUsuario([FromQuery] RangoDeFecha rango)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Expression<Func<vw_HistoricoConsumos, bool>> filter = h => h.fecha >= rango.fechaInicial && h.fecha >= rango.fechaFinal;
                    Func<IQueryable<vw_HistoricoConsumos>, IOrderedQueryable<vw_HistoricoConsumos>> orderBy = q => q.OrderBy(h => h.fecha) ;
                    int limit = 1000;


                    List<vw_HistoricoConsumos> hist = _contenedorTrabajo.vwHistoricoConsumo.GetAll(filter, orderBy, null ).ToList();

                    var resultados = hist
                        .GroupBy(dato => dato.fecha)
                        .Select(grupo => new
                        {
                            Fecha = grupo.Key,
                            MaxPerdida = grupo.Max(dato => dato.Perdida),
                            TipoCliente = grupo.OrderByDescending(dato => dato.Perdida)
                                              .FirstOrDefault()?.NombreCliente,
                            Linea = grupo.OrderByDescending(dato => dato.Perdida)
                                         .FirstOrDefault()?.LineaNombre
                        })
                        .ToList();

                    return Ok(Json(resultados));

                }
                return BadRequest("rango invalido");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        /**/

    }
}
