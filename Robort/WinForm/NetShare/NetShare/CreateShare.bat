net user guest /active:yes
net share Share=F:\ShareFolder /Grant:everyone,full
Icacls F:\ShareFolder /grant Everyone:F /inheritance:e /T
Icacls F:\ShareFolder\*.* /grant Everyone:F /inheritance:e /T


