using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;
using HappyCakes.Models;

namespace HappyCakes.Services
{
    public class FirebaseService
    {
        private readonly IFirebaseClient _client;

        public FirebaseService(FirebaseConfig config)
        {
            _client = config.Client;
        }

        public async Task<bool> RegistrarUsuarioAsync(string email, string senha)
        {
            var usuario = new
            {
                Email = email,
                Senha = senha
            };

            // Salva o usuário no Firebase (ex.: nó "usuarios")
            var response = await _client.SetAsync($"usuarios/{email.Replace(".", "_")}", usuario);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<string> LoginUsuarioAsync(string email, string senha)
        {
            var response = await _client.GetAsync($"usuarios/{email.Replace(".", "_")}");
            var usuario = response.ResultAs<dynamic>();

            if (usuario != null && usuario["Senha"] == senha)
            {
                return "Login bem-sucedido!";
            }
            else
            {
                return "Credenciais inválidas!";
            }
        }

        public async Task<string> SalvarCupcakeAsync(string id, object cupcake)
        {
            var response = await _client.SetAsync($"cupcakes/{id}", cupcake);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? "Cupcake salvo!" : "Erro ao salvar!";
        }
    }

    public class FirebaseSyncService
    {
        private readonly IFirebaseClient _firebaseClient;

        public FirebaseSyncService(IFirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }

        public async Task SyncUserToFirebase(Usuario user)
        {
            var response = await _firebaseClient.SetAsync($"users/{user.Id}", user);
        }

        public async Task DeleteUserFromFirebase(string userId)
        {
            var response = await _firebaseClient.DeleteAsync($"users/{userId}");
        }
    }

}
