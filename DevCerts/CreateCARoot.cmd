makecert.exe ^
-n "CN=Cartomatic CA,O=Cartomatic,OU=MapHive" ^
-r ^
-pe ^
-a sha512 ^
-len 4096 ^
-cy authority ^
-sv Cartomatic_CARoot.pvk ^
-e 01/01/2030 ^
Cartomatic_CARoot.cer
 
pvk2pfx.exe ^
-pvk Cartomatic_CARoot.pvk ^
-spc Cartomatic_CARoot.cer ^
-pfx Cartomatic_CARoot.pfx
REM ^ -po hereGoesPass