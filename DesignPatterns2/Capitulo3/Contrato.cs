﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2.Capitulo3
{
    public class Contrato
    {
        public DateTime Data { get; private set; }
        public string Cliente { get; private set; }
        public TipoContrato Tipo { get; private set; }

        public Contrato(DateTime data, string cliente, TipoContrato tipo)
        {
            this.Data = data;
            this.Cliente = cliente;
            this.Tipo = tipo;
        }

        public void Avanca()
        {
            switch (this.Tipo)
            {
                case TipoContrato.Novo:
                    this.Tipo = TipoContrato.EmAndamento;
                    break;
                case TipoContrato.EmAndamento:
                    this.Tipo = TipoContrato.Acertado;
                    break;
                case TipoContrato.Acertado:
                    this.Tipo = TipoContrato.Concluido;
                    break;
            }
        }

        public Estado SalvaEstado()
        {
            return new Estado(new Contrato(this.Data, this.Cliente, this.Tipo));
        }

        public void Restaura(Estado estado)
        {
            this.Data = estado.Contrato.Data;
            this.Cliente = estado.Contrato.Cliente;
            this.Tipo = estado.Contrato.Tipo;
        }
    }
}
