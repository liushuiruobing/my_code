net user guest /active:yes
net share Share=D:\ShareFolder /Grant:everyone,full
Icacls D:\ShareFolder /grant Everyone:F /inheritance:e /T
Icacls D:\ShareFolder\*.* /grant Everyone:F /inheritance:e /T


