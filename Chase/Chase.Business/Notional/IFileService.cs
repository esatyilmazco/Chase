using System.Collections.Generic;

namespace Chase.Business.Notional
{
    public interface IFileService
    {
        //Bu Method,sınıf parametresi alacak ve bu sınıf Geriye List Dönecek.
        byte[] TransferExcel<T>(List<T> listEntity) where T : class, new();
    }
}