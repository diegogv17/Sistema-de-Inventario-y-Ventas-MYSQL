﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain
{
    public class maestro_detalle_secundario
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioUnit { get; set; }
        public decimal Subtotal { get; set; }
    }
}
