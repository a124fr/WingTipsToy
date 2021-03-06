using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WingTipsToy.Models
{
    public class ProdutoDataBaseInitializer : DropCreateDatabaseIfModelChanges<ProdutoContexto>
    //public class ProdutoDataBaseInitializer : CreateDatabaseIfNotExists<ProdutoContexto>
    {
        protected override void Seed(ProdutoContexto contexto)
        {
            GetCategorias().ForEach(c => contexto.Categorias.Add(c));
            GetProdutos().ForEach(p => contexto.Produtos.Add(p));

            base.Seed(contexto);
        }

        public static List<Categoria> GetCategorias()
        {
            return new List<Categoria>
            {                
                new Categoria()
                {
                    CategoriaID = 1, CategoriaNome = "Carros"
                },                
                new Categoria()
                {
                    CategoriaID = 2, CategoriaNome = "Aeronaves"
                },                
                new Categoria()
                {
                    CategoriaID = 3, CategoriaNome = "Caminhões"
                },                
                new Categoria()
                {
                    CategoriaID = 4, CategoriaNome = "Barcos"
                },                
                new Categoria()
                {
                    CategoriaID = 5, CategoriaNome = "Foguete"
                }
            };
        }

        public static List<Produto> GetProdutos()
        {
            return new List<Produto>
            {
                new Produto() {
                    ProdutoID = 1,
                    ProdutoNome = "Convertible Car",
                    Descricao = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." + "Power it up and let it go!",
                    CaminhoImagem = "carconvert.png",
                    PrecoUnitario = 22.5,
                    CategoriaID = 1
                },
                new Produto() {
                    ProdutoID = 2,
                    ProdutoNome = "Old-time Car",
                    Descricao = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                    CaminhoImagem = "carearly.png",
                    PrecoUnitario = 15.949999999999999,
                    CategoriaID = 1
                },
                new Produto() {
                    ProdutoID = 3,
                    ProdutoNome = "Fast Car",
                    Descricao = "Yes this car is fast, but it also floats in water.",
                    CaminhoImagem = "carfast.png",
                    PrecoUnitario = 32.990000000000002,
                    CategoriaID = 1
                },
                new Produto() {
                    ProdutoID = 4,
                    ProdutoNome = "Super Fast Car",
                    Descricao = "Use this super fast car to entertain guests. Lights and doors work!",
                    CaminhoImagem = "carfaster.png",
                    PrecoUnitario = 8.9499999999999993,
                    CategoriaID = 1
                },
                new Produto() {
                    ProdutoID = 5,
                    ProdutoNome = "Old Style Racer",
                    Descricao = "This old style racer can fly (with user assistance). Gravity controls flight duration." + "No batteries required.",
                    CaminhoImagem = "carracer.png",
                    PrecoUnitario = 34.950000000000003,
                    CategoriaID = 1
                },
                new Produto() { 
                    ProdutoID = 6, 
                    ProdutoNome = "Ace Plane", 
                    Descricao = "Authentic airplane toy. Features realistic color and details.", 
                    CaminhoImagem = "planeace.png", 
                    PrecoUnitario = 95.0, 
                    CategoriaID = 2
                },
                new Produto() {
                    ProdutoID = 7, 
                    ProdutoNome = "Glider",
                    Descricao = "This fun glider is made from real balsa wood. Some assembly required.",
                    CaminhoImagem = "planeglider.png",
                    PrecoUnitario = 4.9500000000000002,
                    CategoriaID = 2
                }, 
                new Produto() {
                    ProdutoID = 8,
                    ProdutoNome = "Paper Plane",
                    Descricao = "This paper plane is like no other paper plane. Some folding required.",
                    CaminhoImagem = "planepaper.png",
                    PrecoUnitario = 2.9500000000000002,
                    CategoriaID = 2
                },
                new Produto() {
                    ProdutoID = 9,
                    ProdutoNome = "Propeller Plane",
                    Descricao = "Rubber band powered plane features two wheels.",
                    CaminhoImagem = "planeprop.png",
                    PrecoUnitario = 32.950000000000003,
                    CategoriaID = 2
                }, 
                new Produto() {
                    ProdutoID = 10, 
                    ProdutoNome = "Early Truck",
                    Descricao = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                    CaminhoImagem = "truckearly.png",
                    PrecoUnitario = 15.0,
                    CategoriaID = 3
                },
                new Produto() {
                    ProdutoID = 11,
                    ProdutoNome = "Fire Truck",
                    Descricao = "You will have endless fun with this one quarter sized fire truck.",
                    CaminhoImagem = "truckfire.png",
                    PrecoUnitario = 26.0,
                    CategoriaID = 3
                },
                new Produto() {
                    ProdutoID = 12,
                    ProdutoNome = "Big Truck",
                    Descricao = "This fun toy truck can be used to tow other trucks that are not as big.",
                    CaminhoImagem = "truckbig.png",
                    PrecoUnitario = 29.0,
                    CategoriaID = 3
                },
                new Produto() {
                    ProdutoID = 13,
                    ProdutoNome = "Big Ship",
                    Descricao = "Is it a boat or a ship. Let this floating vehicle decide by using its " + "artifically intelligent computer brain!",
                    CaminhoImagem = "boatbig.png",
                    PrecoUnitario = 95.0,
                    CategoriaID = 4
                }, 
                new Produto() {
                    ProdutoID = 14,
                    ProdutoNome = "Paper Boat",
                    Descricao = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" + "Some folding required.",
                    CaminhoImagem = "boatpaper.png",
                    PrecoUnitario = 4.9500000000000002,
                    CategoriaID = 4
                },
                new Produto() { 
                    ProdutoID = 15,
                    ProdutoNome = "Sail Boat",
                    Descricao = "Put this fun toy sail boat in the water and let it go!",
                    CaminhoImagem = "boatsail.png",
                    PrecoUnitario = 42.950000000000003,
                    CategoriaID = 4
                },
                new Produto() {
                    ProdutoID = 16,
                    ProdutoNome = "Rocket",
                    Descricao = "This fun rocket will travel up to a height of 200 feet.",
                    CaminhoImagem = "rocket.png",
                    PrecoUnitario = 122.95,
                    CategoriaID = 5 
                }
            };
        }
    }
}