using Microsoft.Data.SqlClient;
using WebCRUDMVCSQL.Models;


namespace WebCRUDMVCSQL.Repositorios
{
    public class UsuarioRepositorio
    {
        public string conexao =
            "Data Source=TQR216785\\SQLEXPRESS;Initial Catalog=CRUD_MVC_SQL_CANAL_DEV;Integrated Security=False;User ID=tds;Password=tds123;TrustServerCertificate=True";

        // CADASTRAR
        public void Cadastrar(Usuarios usuario)
        {
            using (SqlConnection conn =
                new SqlConnection(conexao))
            {
                conn.Open();

                string query =
                @"INSERT INTO Clientes
        (
            Nome,
            Email,
            Senha,
            Cpf,
            Whatsapp,
            Endereco,
            Cidade,
            Estado,
            Pais
        )

        VALUES
        (
            @Nome,
            @Email,
            @Senha,
            @Cpf,
            @Whatsapp,
            @Endereco,
            @Cidade,
            @Estado,
            @Pais
        )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);

                cmd.Parameters.AddWithValue("@Email", usuario.Email);

                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);

                cmd.Parameters.AddWithValue("@Whatsapp", usuario.Whatsapp);

                cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco);

                cmd.Parameters.AddWithValue("@Cidade", usuario.Cidade);

                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                cmd.Parameters.AddWithValue("@Pais", usuario.Pais);

                cmd.ExecuteNonQuery();
            }
        }

        // LOGIN
        public Usuarios FazerLogin(string email, string senha)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                string query =
                    @"SELECT * FROM Clientes
                      WHERE Email = @Email
                      AND Senha = @Senha";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuarios
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString(),
                        Senha = reader["Senha"].ToString()
                    };
                }

                return null;
            }
        }

        // VERIFICAR EMAIL
        public bool EmailExiste(string email)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                string query =
                    "SELECT COUNT(*) FROM Clientes WHERE Email = @E-mail";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);

                int quantidade =
                    (int)cmd.ExecuteScalar();

                return quantidade > 0;
            }
        }

        //Metodo que verifica espacos em branco
        public bool CamposVazios(Usuarios usuario)
        {
            if (usuario== null) return true;

            if (string.IsNullOrWhiteSpace(usuario.Email))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Cpf))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Whatsapp))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Endereco))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Cidade))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Estado))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Pais))
                return true;

            return false;
        }
    }
}