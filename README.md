[     Title        ]  [  ADD ]

[ ] Alışveriş yap
[ ] Dükkana git
[x] Yemek ye
[x] Su iç

GÖREVLER 
1. IdentityTodoList adında bir proje (individual accounts ile) açınız.
2. Migrations klasörünü komple sil.
2. ApplicationUser sınıfı oluştur ve Identity'ye entegre et (user sınıfı)
3. TodoItem entity sınıfı oluştur ve aşağıdaki alanlara sahip olsun.
- Id:int
- Title:string
- Done:boolean
- AuthorId [fk]:string
* Author:ApplicationUser
4. ApplicationUser sınıfına da TodoItems navigasyon property'sini koy
------------------------------ 15dk -----------------------------------
5. Migrations
-----------------------------------------------------------------------
6. Arayüz: Textbox + Button içeren bir form tasarla (yatay)
7. ViewModel: NewTodoItem adında bir view model oluşturun:
- Title
8. Form'a viewmodel'i bind et ve ekle tuşuna basınca gönderilen başlıkla bir yeni TodoItem oluştur
ve veritabanına ekle
BİLGİ: Bir controller içinde giriş yapmış kullanıcının id'si şu satırla alınabilir
string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
------------------------------ 15dk -----------------------------------