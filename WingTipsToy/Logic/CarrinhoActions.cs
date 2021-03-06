using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WingTipsToy.Models;

namespace WingTipsToy.Logic
{
    public class CarrinhoActions
    {
        public string CarrinhoId { get; set; }

        private ProdutoContexto _db = new ProdutoContexto();

        public const string CarrinhoSessaoChave = "CarrinhoId";


        public void IncluirNoCarrinho(int id)
        {
            CarrinhoId = GetCarrinhoId();

            var carrinhoItem = _db.CarrinhoItems.SingleOrDefault(c => c.CarrinhoId == CarrinhoId && c.ProdutoId == id);

            if(carrinhoItem == null)
            {
                carrinhoItem = new CarrinhoItem()
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProdutoId = id,
                    CarrinhoId = CarrinhoId,
                    Produto = _db.Produtos.SingleOrDefault(c=>c.ProdutoID == id),
                    Quantidade = 1,
                    DataCriacao = DateTime.Now
                };

                _db.CarrinhoItems.Add(carrinhoItem);
            }
            else
            {
                carrinhoItem.Quantidade++;
            }

            _db.SaveChanges();
        }

        public string GetCarrinhoId()
        {
            if (HttpContext.Current.Session[CarrinhoSessaoChave] == null)
            {
                if(!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CarrinhoSessaoChave] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCatId = Guid.NewGuid();
                    HttpContext.Current.Session[CarrinhoSessaoChave] = tempCatId.ToString();
                }
            }

            return HttpContext.Current.Session[CarrinhoSessaoChave].ToString();
        }

        public List<CarrinhoItem> GetCarrinhoItems()
        {
            CarrinhoId = GetCarrinhoId();
            return _db.CarrinhoItems.Where(c => c.CarrinhoId == CarrinhoId).ToList();
        }

        public double GetTotal()
        {
            CarrinhoId = GetCarrinhoId();

            double? total = 0.0;

            total = (from carrinhoItens in _db.CarrinhoItems.Where(c => c.CarrinhoId == CarrinhoId)
                     select carrinhoItens.Quantidade * carrinhoItens.Produto.PrecoUnitario).Sum();

            return total ?? 0.0;
        }

        public CarrinhoActions GetCarrinho(HttpContext context)
        {
            var carrinho = new CarrinhoActions();
            carrinho.CarrinhoId = carrinho.GetCarrinhoId();
            return carrinho;
        }

        public void AtualizarCarrinhoBD(string carrinhoId, CarrinhoAtualiza[] carrinhoAtualiza)
        {
            using(var db = new ProdutoContexto())
            {
                try
                {
                    int CartItemCount = carrinhoAtualiza.Count();
                    List <CarrinhoItem> myCart = GetCarrinhoItems();

                    foreach(var carrinhoItem in myCart)
                    {
                        // Itera através de todas aslinhas na lista de carrinho
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if(carrinhoItem.Produto.ProdutoID == carrinhoAtualiza[i].ProdutoId)
                            {
                                if(carrinhoAtualiza[i].QuantidadeComprada < 1 || carrinhoAtualiza[i].RemoveItem == true)
                                {
                                    RemoveItem(carrinhoId, carrinhoItem.ProdutoId);
                                }
                                else
                                {
                                    UpdateItem(carrinhoId, carrinhoItem.ProdutoId, carrinhoAtualiza[i].QuantidadeComprada);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERRO: Não foi possivel atualizar o Banco de dados - " + ex.Message.ToString(), ex);
                }
            }
        }

        public void RemoveItem(string removeCarrinhoID, int removeProdutoID)
        {
            using (var db = new ProdutoContexto())
            {
                try
                {
                    var menuItem = (from c in db.CarrinhoItems
                                    where c.CarrinhoId == removeCarrinhoID && c.Produto.ProdutoID == removeProdutoID select c).FirstOrDefault();

                    if (menuItem != null)
                    {
                        db.CarrinhoItems.Remove(menuItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: Não foi possível Remover o item do Carrinho - " + ex.Message.ToString(), ex);
                }
            }
        }

        public void UpdateItem(string atualizaCarrinhoID, int atualizaProdutoId, int quantidade)
        {
            using (var db = new ProdutoContexto())
            {
                try
                {
                    var menuItem = (from c in db.CarrinhoItems where c.CarrinhoId == atualizaCarrinhoID &&
                                    c.ProdutoId == atualizaProdutoId select c).FirstOrDefault();

                    if(menuItem != null)
                    {                        
                        menuItem.Quantidade = quantidade;
                        db.SaveChanges();

                        //var entry = db.Entry(menuItem);

                        //if (entry != null)
                        //{
                        //    entry.State = EntityState.Modified;
                        //    db.SaveChanges();
                        //}
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: Não foi possível atualizar o item do carrinho - " + ex.Message, ex);
                }
            }
        }

        public void CarrinhoVazio()
        {
            CarrinhoId = GetCarrinhoId();

            var carrinhoItems = _db.CarrinhoItems.Where(c => c.CarrinhoId == CarrinhoId);

            foreach (var carrinhoItem in carrinhoItems)
            {
                _db.CarrinhoItems.Remove(carrinhoItem);
            }

            _db.SaveChanges();
        }

        public int GetContador()
        {
            CarrinhoId = GetCarrinhoId();

            //var contexto = new ProdutoContexto();
            // Obtem a contagem de cada item no carrinho e as soma
            //int? contador = (from carrinhoItems in contexto.CarrinhoItems
            //                 where carrinhoItems.CarrinhoId == CarrinhoId
            //                 select carrinhoItems.Quantidade).Sum();
            //return contador ?? 0;

            var lista = (from l in _db.CarrinhoItems
                        where l.CarrinhoId == CarrinhoId
                        select l).ToList();

            var contador = 0;
            if(lista != null && lista.Count > 0)
            {
                contador = (from c in lista
                            select c.Quantidade).Sum();
            }

            //contexto.Dispose();

            return contador;
        }


        public struct CarrinhoAtualiza
        {
            public int ProdutoId { get; set; }
            public int QuantidadeComprada { get; set; }
            public bool RemoveItem { get; set; }
        }
    }
}