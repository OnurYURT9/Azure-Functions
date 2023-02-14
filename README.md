## AZURE FUNCTİON ÖZELLİKLERİ

Herhangi bir altyapı işlemine gerek kalmaksızın kodu ayağa kaldırıp serverless mimari inşa edilmesini sağlar.

Çoklu dil desteği sağlar.

Diğer Azure servislerle entegre çalışır.(Bindingler sayesinde gerçekleşir)

NPM, Nuget gibi paket yöneticileri kullanılabilir.
 ## AZURE FUNCTİON BAĞLI OLDUĞU SERVİSLER

Azure function oluştuğumuz zaman azure storage da oluşturmak zorundayız. Azure function içerisindeki durum bilgileri azure storage içerisinde tutulur. Bir tane Azure storage oluşturup birden fazla Azure function a bağlayabiliriz.

Application Insights: İsteğe bağlı olarak gelir. Bizim canlıya aldığımız uygulamamızın davranışlarını izlemememize imkan veren bir monitoring(izleme) işlemidir. Default oluşturunca enable olarak gelir.

## AZURE FUNCTİON TRİGGER TİPLERİ

Bir function çalışabilmesi için mutlaka tetiklenmesi gerekir.

Http Trigger ve Timer Trigger haricindeki trigger çeşitleri diğer azure servislerine bağlıdır. Http Trigger ve Timer trigger herhangi azure servis kullanmaz. Dışarıdan vereceğimiz komutlarla bu ikisini tetikleyebiliriz.

<strong>HttpTrigger:</strong> Httptrigger ile bir function oluşturduğumuzda bize endpoint verir bu endpointe istek yaptığımızda tigger tetiklenir.

<strong>TimerTrigger:</strong> Belli aralıklarla çalışacak kodumuzda tercih ederiz.

<strong>QueueTrigger:</strong> Kuyruğa mesaj yazıldığında tetiklenir.

<strong>BlobTrigger:</strong>  Blob'a yeni blob düştüğünde tetiklenir.

<strong>host.json:</strong>  Çalışacak function'la ilgili runtime ile ilgili bilgiler tutulur.

<strong>localsettings.json:</strong>  Development esnasında localde bilgiler tutulur. Canlıya cloud ortama gitmez.

## HTTPTRİGGER

Httptrigger ile bir function oluşturduğumuzda bize endpoint verir bu endpointe istek yaptığımızda tigger tetiklenir.

Route

Body Okuma

QueryString Okuma
## Authorization

Anonymous: Herkes tarafından trigger'a erişebilir.

Function: Function seviyesinde erişim belirleyicisi anlamına gelir.Azure portal üzerinden erişim belirleyicisi olarak kullanılacak ‘Function Key’ verilmekte ve tüm erişim bu key üzerinden gerçekleştirilmektedir.

Admin: ‘Function Key’e nazaran ‘Master Key’ ile erişim sağlanmasını gerçekleştirmektedir.

Function App: default key-function key

En yüksek seviyede koruma admin seviyesindedir.
## CORS(Cross Origin Resource Sharing)

Kod yazdığımızda bu kodu tüketecek kaynak tarayıcı ise mutlaka cors özelliğinin ayarlanması lazım. Cors güvenliği gevşetme yöntemidir. Sadece tarayıcılar için geçerlidir. Tarayıcılar normalde kendi içerisinden dış bir kaynağa istek yapıldığında bu istediği reddederler güvenlik için. CORS ayarı yapıldığında kullanıcı tarayıcı içerisinden isteğin yapılmasına izin verdiğini belirtir. Böylece tarayıcı güvenliği esnetilmiş olur.
## BİNDİNGS

Azure functions bindings Azure functions'ları diğer azure servislerine bağlamak için kullanmamızı sağlayan özelliktir.Binding sayesinde ekstra kod yazmaksızın Azure içerisindeki birçok servise bağlantı gerçekleştirilebilmektedir. Binding sadece azure servisler ile yapılır.

Input Bindings:

Azure Function’ın ilgili servislere ekstradan kod yazmaksızın bağlanmasıdır. Function’ımız bu input binding üzerinden verileri okuyabilir, işleyebilir. Varsayılan binding türüdür.

Output Binding:

Azure Function’ın ilgili servislerden data’yı dışarıya göndermesi ve işletmesidir.

Binding, compile olabilen dillerde(Java, C#) attributes/annotations gibi yapılarla gerçekleştirilirken(bunlar yine çalıştığında function.json dosyasına dönüştürülür), compile olmayan dillerde(Node.JS) ise direkt olarak ‘function.json’ dosyası üzerinden gerçekleştirilmektedir.

Binding işlemi yaparken 3 tane yapıyı mutlaka belirtmemiz lazım:

*Direction(in/out)

*Type(table/queue/blob)

*Name

HttpTrigger gizli bir input bindingtir.
