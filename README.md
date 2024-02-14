vscode

git submodule add PATH.git

git submodule update --init

git submodule update --recursive --remote

---push to origin
$ cd your_submodule
$ git checkout master
<hack,edit>
$ git commit -a -m "commit in submodule"
$ git push
$ cd ..
$ git add your_submodule
$ git commit -m "Updated submodule"

vstudio
1.	Visual Studio’da projenizi açın.
 
2.	Git sekmesine geçin ve “Team Explorer” penceresini açın.
	
3.	“Manage Remotes” (Uzak Depoları Yönet) seçeneğini tıklayın.

4.	“Repository Settings” (Depo Ayarları) altında “Submodules” (Alt Modüller) sekmesini bulun.

5.	“Add” (Ekle) düğmesini tıklayarak bir submodule ekleyin ve PATH.git URL’sini girin.

6.	Ekledikten sonra “Update” (Güncelle) düğmesine tıklayarak submodule’leri güncelleyin.

7.	Gerekirse, submodule’leri güncellemek ve alt modülleri de güncellemek için “Update Recursively” (Rekürsif Olarak Güncelle) seçeneğini kullanabilirsiniz.
