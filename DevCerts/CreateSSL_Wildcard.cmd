makecert.exe ^
-n "CN=*.%1,O=Cartomatic,OU=MapHive" ^
-iv Cartomatic_CARoot.pvk ^
-ic Cartomatic_CARoot.cer ^
-pe ^
-a sha512 ^
-len 4096 ^
-b 01/01/2016 ^
-e 01/01/2030 ^
-sky exchange ^
-eku 1.3.6.1.5.5.7.3.1 ^
-sv all.%1.pvk ^
all.%1.cer

pvk2pfx.exe ^
-pvk all.%1.pvk ^
-spc all.%1.cer ^
-pfx all.%1.pfx
REM ^ -po hereGoesPass