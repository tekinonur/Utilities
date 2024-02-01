using System.ComponentModel;

namespace Utilities.Enums;

public enum ResponseStatus
{
    /// <summary>
    /// Başarılı senaryo
    /// </summary>
    Success = 0,
    /// <summary>
    /// Genel hata durumları
    /// </summary>
    Error = 1,
    /// <summary>
    /// Verify edilmemiş kullanıcıs
    /// </summary>
    VERIFY_USER = 2,
    /// <summary>
    /// Kayıtlı kullanıcı
    /// Mobilde kayıtlı hata mesajı var
    /// </summary>
    EXISTING_USER = 3,
    /// <summary>
    /// Input parametre hatası
    /// </summary>
    INVALID_ARGUMENT = 4,
    /// <summary>
    /// Şifre email hatası, kullanıc bulunamaması, geçersiz token yetkisi işlem
    /// 401 kodu atılmayan durumlarda atılır sadece
    /// </summary>
    UNAUTHORIZED_ACCES = 5,
    /// <summary>
    /// Tekrarlı işlemler, like edilen bir postun tekrar like edilmesi, verify bir kullanıcnın verify edilmeye çalışması
    /// </summary>
    [Description("Böyle bir istekte daha önce bulundunuz.")]
    CONFLICT = 6,
    /// <summary>
    /// Token vs geçerlilik süresi dolmuş
    /// </summary>
    EXPIRED = 7,
    /// <summary>
    /// Kullanıcı bulunamadı
    /// </summary>
    [Description("Kullanıcı bulunamadı.")]
    USER_NOT_FOUND = 8,
    /// <summary>
    /// Daha önce kayıtlı email
    /// </summary>
    [Description("Bu e-posta adresi kullanılamaz, lütfen başka bir e-posta adresi ile deneyiniz.")]
    REGISTERED_EMAIL = 9,
    /// <summary>
    /// Daha önce kayıtlı telefon
    /// </summary>
    [Description("Bu telefon numarası kullanılamaz, lütfen başka bir telefon numarası ile deneyiniz.")]
    REGISTERED_PHONE = 10,
    /// <summary>
    /// Daha önce kayıtlı SSO (google,apple,facebook..)
    /// </summary>
    [Description("Kayıt olmaya çalıştığınız hesap kullanılamaz, lütfen başka bir hesap deneyiniz.")]
    REGISTERED_SSO = 11,
    /// <summary>
    /// InvitationCode geçersiz ise, kullanım adedi dolmuştur vs
    /// </summary>
    [Description("Geçersiz davet kodu. Aramıza katılmak için davet kodu talep edebilirsin")]
    INVALID_INVITATION_CODE = 12
}