using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica {
    public class DueñoService {

        private readonly ConnectionManager _conexion;
        private readonly DueñoRepository _repositorio;
        public DueñoService (string connectionString) {
            _conexion = new ConnectionManager (connectionString);
            _repositorio = new DueñoRepository (_conexion);
        }

        public GuardarDueñoResponse Guardar (Dueño dueño) {
            try {
                _conexion.Open ();
                _repositorio.Guardar (dueño);
                _conexion.Close ();
                return new GuardarDueñoResponse (dueño);
            } catch (Exception e) {
                return new GuardarDueñoResponse ($"Error de la Aplicacion: {e.Message}");
            } finally { _conexion.Close (); }
        }

        public class GuardarDueñoResponse {
            public GuardarDueñoResponse(Dueño dueño)
            {
                Error = false;
                Dueño = dueño;
            }
            public GuardarDueñoResponse (string mensaje) {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Dueño Dueño { get; set; }
        }

        public List<Dueño> ConsultarTodos () {
            _conexion.Open ();
            List<Dueño> dueños = _repositorio.ConsultarTodos ();
            _conexion.Close ();
            return dueños;
        }

    }
}