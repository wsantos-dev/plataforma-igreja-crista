using System;

namespace PlataformaRedencao.Application.Seguranca;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);
}
