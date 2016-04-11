makecert.exe ^
-n CN=%1,O=Cartomatic,OU=MapHive ^
-iv Cartomatic_CARoot.pvk ^
-ic Catomatic_CARoot.cer ^
-pe ^
-a sha512 ^
-len 4096 ^
-b 01012016 ^
-e 01012030 ^
-sky exchange ^
-eku 1.3.6.1.5.5.7.3.1 ^
-sv %1.pvk ^
%1.cer

pvk2pfx.exe ^
-pvk %1.pvk ^
-spc %1.cer ^
-pfx %1.pfx
REM ^ -po hereGoesPass