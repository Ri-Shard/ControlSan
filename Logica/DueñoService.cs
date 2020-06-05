using System.ComponentModel;
using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class DueñoService
    {
        private readonly RestauranteContext _context;

        public DueñoService(RestauranteContext context)
        {
            _context = context;
        }

        public GuardarDueñoResponse Guardar(Dueño dueño)
        {
            try
            {
                var due = _context.Dueños.Find(dueño.ID);
                if (due != null)
                {
                    return new GuardarDueñoResponse("Error el Dueño ya se encuentra registrado");
                }

                _context.Dueños.Add(dueño);
                _context.SaveChanges();

                return new GuardarDueñoResponse(dueño);
            }
            catch (Exception e)
            {
                return new GuardarDueñoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public class GuardarDueñoResponse
        {
            public GuardarDueñoResponse(Dueño dueño)
            {
                Error = false;
                Dueño = dueño;
            }
            public GuardarDueñoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Dueño Dueño { get; set; }
        }

        public List<Dueño> ConsultarTodos()
        {
            List<Dueño> dueños = _context.Dueños.ToList();
            return dueños;
        }


        public string Eliminar(string ID)
        {
            try
            {
                var dueño = _context.Dueños.Find(ID);
                if (dueño != null)
                {
                    _context.Dueños.Remove(dueño);
                    _context.SaveChanges();
                    return ($"El registro {dueño.ID} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {ID} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }

        }

        public string Modificar(Dueño dueñoN)
        {
            try
            {
                var dueñoV = _context.Dueños.Find(dueñoN.ID);
                if (dueñoV != null)
                {
                    dueñoV.ID = dueñoN.ID;
                    dueñoV.Nombre = dueñoN.Nombre;
                    dueñoV.Apellido = dueñoN.Apellido;
                    _context.Dueños.Update(dueñoV);
                    _context.SaveChanges();
                    return ($"El registro {dueñoN.ID} se ha modificado satisfactoriamente");

                }
                else
                {
                    return ($"Lo sentimos, {dueñoN.ID} no se encuentra registrado.");

                }
            }
            catch (Exception e)
            {
                return ($"Error de la aplicacion: {e.Message}.");

            }
        }

        public Dueño BuscarPorID(string ID)
        {

            Dueño dueño = _context.Dueños.Find(ID);
            return dueño;
        }
    }
}
