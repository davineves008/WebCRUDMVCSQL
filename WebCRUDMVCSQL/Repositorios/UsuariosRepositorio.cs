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
    Nome, Idade, Sexo, Email, Senha,
    CPF, Whatsapp, Endereco, Logradouro,
    Numero_Casa, Complemento, Bairro,
    Cidade, Estado, Pais, Estado_Civil, CEP
)
VALUES
(
    @Nome, @Idade, @Sexo, @Email, @Senha,
    @CPF, @Whatsapp, @Endereco, @Logradouro,
    @Numero_Casa, @Complemento, @Bairro,
    @Cidade, @Estado, @Pais, @Estado_Civil, @CEP
)";

                SqlCommand cmd =
                    new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Idade", usuario.Idade);
                cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", usuario.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
                cmd.Parameters.AddWithValue("@Whatsapp", usuario.Whatsapp);
                cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Logradouro", usuario.Logradouro ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Numero_Casa", usuario.Numero_Casa);
                cmd.Parameters.AddWithValue("@Complemento", usuario.Complemento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Cidade", usuario.Cidade ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Pais", usuario.Pais ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado_Civil", usuario.Estado_Civil ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CEP", usuario.CEP ?? (object)DBNull.Value);
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
                    "SELECT COUNT(*) FROM Clientes WHERE Email = @Email";

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
            if (usuario == null)
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                return true;

            if (usuario.Idade <= 0)
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Sexo))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Estado_Civil))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Endereco))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.CEP))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Logradouro))
                return true;

            if (usuario.Numero_Casa <= 0)
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Bairro))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Cidade))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Estado))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Pais))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Whatsapp))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.CPF))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Email))
                return true;

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                return true;

            return false;
        }
    }
}