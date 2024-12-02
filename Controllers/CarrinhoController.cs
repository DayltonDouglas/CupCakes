using HappyCakes.Data;
using HappyCakes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HappyCakes.Extensions;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class CarrinhoController : Controller
{
    public IActionResult Index()
    {
        var carrinho = HttpContext.Session.GetObjectFromJson<Dictionary<int, int>>("Carrinho") ?? new Dictionary<int, int>();
        return View(carrinho);
    }

    [HttpPost]
    public IActionResult Adicionar(int cupcakeId, int quantidade)
    {
        if (User.Identity == null || !User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        // Obter carrinho da sessão ou inicializar
        var carrinho = HttpContext.Session.GetObjectFromJson<Dictionary<int, int>>("Carrinho") ?? new Dictionary<int, int>();

        // Atualizar ou adicionar cupcake ao carrinho
        if (carrinho.ContainsKey(cupcakeId))
        {
            carrinho[cupcakeId] += quantidade;
        }
        else
        {
            carrinho[cupcakeId] = quantidade;
        }

        // Salvar carrinho na sessão
        HttpContext.Session.SetObjectAsJson("Carrinho", carrinho);

        // Atualizar a quantidade total de itens
        HttpContext.Session.SetInt32("CarrinhoQuantidade", carrinho.Values.Sum());

        // Redirecionar de volta para a página de cupcakes
        return RedirectToAction("Index", "CupCake");
    }

    [HttpPost]
    public IActionResult RemoverItem(int cupcakeId)
    {
        var carrinho = HttpContext.Session.GetObjectFromJson<Dictionary<int, int>>("Carrinho") ?? new Dictionary<int, int>();

        if (carrinho.ContainsKey(cupcakeId))
        {
            carrinho.Remove(cupcakeId);
            HttpContext.Session.SetObjectAsJson("Carrinho", carrinho);
            HttpContext.Session.SetInt32("CarrinhoQuantidade", carrinho.Sum(i => i.Value));
        }

        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var carrinho = HttpContext.Session.GetObjectFromJson<Dictionary<int, int>>("Carrinho");
        if (carrinho == null || !carrinho.Any())
            return RedirectToAction("Index", "CupCake");

        var total = carrinho.Sum(item => /* substitua pelo cálculo real */ item.Value * 10);
        ViewBag.Total = total;
        return View(carrinho);
    }
}
