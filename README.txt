****************chạy web admin *******************************
B1 : chạy file script DB (VolunteerWorldDB.script): MS SQL server => Database tên vl6
B2 : Chạy OpenAPI : Mở bằng visual studio 2017(Nháy đúp vào file API.sln trong OpenAPI) (Để chạy API local server cho web ADMIN)
		   Vào file 'ConnectionString.config' sửa lại chuỗi kết nối 
			Source, pwd = Server name, password để login vào SQL server 
		<add name="EntityConnection" connectionString="Data Source=*********;Initial Catalog=vl6;uid=sa;pwd=**********;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
     ==> Run 
B3 : Chạy WebAdmin : Mở bẳng Visual code (Mở visual code => file => open folder => Chọn folder WebAdmin)
		Trên toolbar chọn Terminal -> New Terminal -> trong terminal dùng lệnh : npm install -> npm run serve 
		Sau khi run xong chọn 1 link để mở web admin trên Browser : Ex: http://localhost:8080
B4 : Account : vu@gmail.com , password : 123@123Aa 
************************ Vue.js *****************************
Đây là template web admin dùng Rest APi
B1 : Sửa view của Web admin (Dùng tiếng việt)
B2 : Ghép phần Back end (Rest API ) cửa JeanShop vào template 
