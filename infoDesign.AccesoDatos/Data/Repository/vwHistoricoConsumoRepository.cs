using infoDesign.AccesoDatos.Data.Repository.IRepository;
using infoDesign.modelos;
using infoDesign.modelos.consumoPorTramo;
using infoDesign.modelos.HistoriaPorTipoUsuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoDesign.AccesoDatos.Data.Repository
{
    public class vwHistoricoConsumoRepository :Repository<vw_HistoricoConsumos> ,  IvwHistoricoConsumoRepository
    {
        private readonly MyDbContext _db;
        public vwHistoricoConsumoRepository(MyDbContext db) : base(db) { _db = db; }

        public List<consumoPorTramo> ObtenerHistorialLineas(List<vw_HistoricoConsumos> datos  )
        {
            var resultado = new List<consumoPorTramo>();

            var gruposPorLinea = datos.GroupBy(dato => new { dato.idLinea, dato.LineaNombre });

            foreach (var grupoLinea in gruposPorLinea)
            {
                var idLinea = grupoLinea.Key.idLinea;
                var nombreLinea = grupoLinea.Key.LineaNombre;

                var historialLinea = new consumoPorTramo
                {
                    IdLinea = idLinea,
                    NombreLinea = nombreLinea,
                    Fechas = new Dictionary<DateTime, List<HistorialCliente>>()
                };

                var gruposPorFecha = grupoLinea.GroupBy(dato => dato.fecha);

                foreach (var grupoFecha in gruposPorFecha)
                {
                    var fecha = grupoFecha.Key;
                    var datosFecha = new List<HistorialCliente>();

                    foreach (var dato in grupoFecha)
                    {
                        datosFecha.Add(new HistorialCliente
                        {
                            IdCliente = dato.idTipCliente,
                            NombreCliente = dato.NombreCliente,
                            Consumo = dato.Consumo,
                            Costo = dato.Costo,
                            Perdida = dato.Perdida
                        });
                    }

                    historialLinea.Fechas.Add(fecha, datosFecha);
                }

                resultado.Add(historialLinea);
            }

            return resultado;
        }



        public List<HistoriaPorTipoUsuario> ObtenerHistoriaPorTipoUsuario(List<vw_HistoricoConsumos> datos)
        {
            var resultado = new List<HistoriaPorTipoUsuario>();

            foreach (var dato in datos)
            {
                var historiaPorTipoUsuario = resultado.FirstOrDefault(h => h.IdTipCliente == dato.idTipCliente);
                if (historiaPorTipoUsuario == null)
                {
                    historiaPorTipoUsuario = new HistoriaPorTipoUsuario
                    {
                        IdTipCliente = dato.idTipCliente,
                        Nombre = dato.NombreCliente,
                        Historia = new List<HistoriaFecha>()
                    };
                    resultado.Add(historiaPorTipoUsuario);
                }

                var historiaTramo = new HistoriaTramo
                {
                    IdLinea = dato.idLinea,
                    LineaNombre = dato.LineaNombre,
                    Consumo = dato.Consumo,
                    Perdida = dato.Perdida,
                    Costo = dato.Costo
                };

                // Buscar la fecha correspondiente en la historia del tipo de usuario
                var fechaHistoria = historiaPorTipoUsuario.Historia.FirstOrDefault(h => h.Fecha == dato.fecha);
                if (fechaHistoria == null)
                {
                    fechaHistoria = new HistoriaFecha
                    {
                        Fecha = dato.fecha,
                        Datos = new List<HistoriaTramo>()
                    };
                    historiaPorTipoUsuario.Historia.Add(fechaHistoria);
                }

                fechaHistoria.Datos.Add(historiaTramo);
            }

            return resultado;
        }

    }
}
