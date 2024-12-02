using FireSharp.Interfaces;
using FireSharp.Response;
using HappyCakes.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class AccountController : Controller
{
    private readonly IFirebaseClient _firebaseClient;

    public AccountController(IFirebaseClient firebaseClient)
    {
        _firebaseClient = firebaseClient;
    }

    // Tela de Login
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string email, string senha)
    {
        FirebaseResponse response = await _firebaseClient.GetAsync($"Usuarios/{email.Replace(".", "_")}");
        Usuario user = response.ResultAs<Usuario>();

        if (user == null || user.Senha != senha)
        {
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View();
        }

        HttpContext.Session.SetString("UserEmail", email);
        return RedirectToAction("Index", "Cupcake");
    }

    // Logout
    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserEmail");
        return RedirectToAction("Login");
    }

    // Registro
    [HttpGet]
    public IActionResult Registrar() => View();

    [HttpPost]
    public async Task<IActionResult> Registrar(string nome, string email, string senha, string confirmarSenha)
    {
        if (senha != confirmarSenha)
        {
            ModelState.AddModelError("", "As senhas não coincidem.");
            return View();
        }

        FirebaseResponse existingUserResponse = await _firebaseClient.GetAsync($"Usuarios/{email.Replace(".", "_")}");
        if (existingUserResponse.Body != "null")
        {
            ModelState.AddModelError("", "Este e-mail já está registrado.");
            return View();
        }

        var user = new Usuario { Nome = nome, Email = email, Senha = senha };
        SetResponse response = await _firebaseClient.SetAsync($"Usuarios/{email.Replace(".", "_")}", user);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            HttpContext.Session.SetString("UserEmail", email);
            return RedirectToAction("Index", "Cupcake");
        }

        ModelState.AddModelError("", "Erro ao registrar usuário. Tente novamente.");
        return View();
    }

    // Redefinição de Senha
    [HttpGet]
    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        FirebaseResponse response = await _firebaseClient.GetAsync($"Usuarios/{email.Replace(".", "_")}");
        Usuario user = response.ResultAs<Usuario>();

        if (user == null)
        {
            ModelState.AddModelError("", "Usuário não encontrado.");
            return View();
        }

        // Aqui você configuraria um envio de e-mail para redefinição.
        ViewBag.Message = "Link de redefinição de senha enviado!";
        return View();
    }

    public IActionResult ForgotPasswordConfirmation() => View();
}
