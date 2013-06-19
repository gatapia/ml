REM DOWNLOAD FROM: http://sourceforge.net/projects/weka/files/weka-packages/
for /f %%f in ('dir /b packages\*.jar') do J:\dev\tools\ikvm\bin\ikvmc -target:library packages\%%f -out:packages\%%f.dll