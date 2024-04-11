using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccesoModelos
{
    public class Ingrediente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public bool Disponibilidad { get; set; }

        [JsonIgnore]
        public List<Producto> Productos { get; set; }

        public Ingrediente(string nombre, double precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Disponibilidad = Stock != 0 ? true : false;
        }        
        public Ingrediente()
        {

        }
        public List<Ingrediente> ListaIngredientes()
        {
            Ingrediente pan = new Ingrediente("Pan de papa", 100.00, 0);
            Ingrediente tomate = new Ingrediente("Tomate", 100.00, 20);
            Ingrediente lechuga = new Ingrediente("Lechuga", 100.00, 20);
            Ingrediente carne = new Ingrediente("Carne", 500.00, 200);
            Ingrediente panceta = new Ingrediente("Panceta", 300.00, 100);
            Ingrediente queso = new Ingrediente("Queso", 200.00, 100);
            Ingrediente jamon = new Ingrediente("Jamon", 200.00, 100);
            Ingrediente champiñon = new Ingrediente("Champiñon", 300, 100);
            Ingrediente huevo = new Ingrediente("Huevo", 200, 100);
            Ingrediente salsa_ketchup = new Ingrediente("Salsa ketchup", 50.00, 200);
            Ingrediente salsa_mayonesa = new Ingrediente("Salsa mayonesa", 50.00, 0);

            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(pan);
            ingredientes.Add(tomate);
            ingredientes.Add(lechuga);
            ingredientes.Add(carne);
            ingredientes.Add(panceta);
            ingredientes.Add(queso);
            ingredientes.Add(jamon);
            ingredientes.Add(champiñon);
            ingredientes.Add(huevo);
            ingredientes.Add(salsa_ketchup);
            ingredientes.Add(salsa_mayonesa);

            return ingredientes;
        }

        public List<Ingrediente> HamburguesaDeQueso()
        {
            Ingrediente pan = new Ingrediente("Pan de papa", 100.00, 0);
            Ingrediente carne = new Ingrediente("Carne", 500.00, 200);
            Ingrediente queso = new Ingrediente("Queso", 200.00, 100);
            Ingrediente salsa_ketchup = new Ingrediente("Salsa ketchup", 50.00, 200);
            Ingrediente salsa_mayonesa = new Ingrediente("Salsa mayonesa", 50.00, 0);

            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(pan);
            ingredientes.Add(carne);
            ingredientes.Add(carne);
            ingredientes.Add(queso);
            ingredientes.Add(salsa_ketchup);
            ingredientes.Add(salsa_mayonesa);
            return ingredientes;
        }        
        public List<Ingrediente> HamburguesaDePanceta()
        {
            Ingrediente pan = new Ingrediente("Pan de papa", 100.00, 0);
            Ingrediente carne = new Ingrediente("Carne", 500.00, 200);
            Ingrediente panceta = new Ingrediente("Panceta", 300.00, 100);
            Ingrediente salsa_ketchup = new Ingrediente("Salsa ketchup", 50.00, 200);
            Ingrediente salsa_mayonesa = new Ingrediente("Salsa mayonesa", 50.00, 0);

            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(pan);
            ingredientes.Add(carne);
            ingredientes.Add(carne);
            ingredientes.Add(panceta);
            ingredientes.Add(salsa_ketchup);
            ingredientes.Add(salsa_mayonesa);
            return ingredientes;
        }        
        public List<Ingrediente> HamburguesaVegetariana()
        {
            Ingrediente pan = new Ingrediente("Pan de papa", 100.00, 0);
            Ingrediente tomate = new Ingrediente("Tomate", 100.00, 20);
            Ingrediente lechuga = new Ingrediente("Lechuga", 100.00, 20);
            Ingrediente champiñon = new Ingrediente("Champiñon", 300, 100);
            Ingrediente huevo = new Ingrediente("Huevo", 200, 100);
            Ingrediente salsa_ketchup = new Ingrediente("Salsa ketchup", 50.00, 200);
            Ingrediente salsa_mayonesa = new Ingrediente("Salsa mayonesa", 50.00, 0);

            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(pan);
            ingredientes.Add(tomate);
            ingredientes.Add(lechuga);
            ingredientes.Add(champiñon);
            ingredientes.Add(huevo);
            ingredientes.Add(salsa_ketchup);
            ingredientes.Add(salsa_mayonesa);
            return ingredientes;
        }        
        public List<Ingrediente> HamburguesaCompleta()
        {
            Ingrediente pan = new Ingrediente("Pan de papa", 100.00, 0);
            Ingrediente tomate = new Ingrediente("Tomate", 100.00, 20);
            Ingrediente lechuga = new Ingrediente("Lechuga", 100.00, 20);
            Ingrediente carne = new Ingrediente("Carne", 500.00, 200);
            Ingrediente queso = new Ingrediente("Queso", 200.00, 100);
            Ingrediente jamon = new Ingrediente("Jamon", 200.00, 100);
            Ingrediente huevo = new Ingrediente("Huevo", 200, 100);
            Ingrediente salsa_ketchup = new Ingrediente("Salsa ketchup", 50.00, 200);
            Ingrediente salsa_mayonesa = new Ingrediente("Salsa mayonesa", 50.00, 0);

            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(pan);
            ingredientes.Add(tomate);
            ingredientes.Add(lechuga);
            ingredientes.Add(carne);
            ingredientes.Add(queso);
            ingredientes.Add(jamon);
            ingredientes.Add(huevo);
            ingredientes.Add(salsa_ketchup);
            ingredientes.Add(salsa_mayonesa);
            return ingredientes;
        }        
        public List<Ingrediente> HamburguesaInfantil()
        {
            Ingrediente pan = new Ingrediente("Pan de papa", 100.00, 0);
            Ingrediente carne = new Ingrediente("Carne", 500.00, 200);
            Ingrediente queso = new Ingrediente("Queso", 200.00, 100);
            Ingrediente salsa_ketchup = new Ingrediente("Salsa ketchup", 50.00, 200);
            Ingrediente salsa_mayonesa = new Ingrediente("Salsa mayonesa", 50.00, 0);

            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(pan);
            ingredientes.Add(carne);
            ingredientes.Add(queso);
            ingredientes.Add(salsa_ketchup);
            ingredientes.Add(salsa_mayonesa);
            return ingredientes;
        }


        public List<Ingrediente> IngredientesDisponibles(List<Ingrediente> ingredientes)
            {
            List<Ingrediente> ingredientes_disponibles = new List<Ingrediente>();

            foreach(var item in ingredientes)
            {
                if(item.Disponibilidad == true)
                {
                    ingredientes_disponibles.Add(item);           
                }
                else
                {
                    ingredientes_disponibles.Remove(item);
                }
            }
            return ingredientes_disponibles;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Precio: {Precio}, Stock: {Stock}, Disponibilidad: {Disponibilidad}";
        }
    }
}
