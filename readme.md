## ���������� SOLID

### 1. **������� ������������ ��������������� (SRP)**:
- ����� `VeterinaryClinic` �������� ������ �� �������� �������� ��������  
- ����� `ZooServices` ��������� ����������� �������� � �������� ���

### 2. **������� ����������/���������� (OCP)**:
- ����� ���� �������� (��������, `Elephant`) ����������� ����� ������������ �� `Animal` ��� ��������� ������������� ����

### 3. **������� ����������� ������ (LSP)**:
- ��� �������� ��������� `IAlive`, ��� ����������� ������� �������� `Food`

### 4. **������� ���������� ����������� (ISP)**:
- ���������� `IAlive` (��� ����� �������) � `IInventory` (��� ���������) ���������, ����� �������� "����������" ����������������

### 5. **������� �������� ������������ (DIP)**:
- `ZooServices` ������� �� ���������� `IVeterinaryClinic`, � �� �� ���������� ����������

---

## �����������

��� ������ ���������� ����������:  
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) (DI-���������)

---

## ���������� �� �������

1. ���������� �����������:  
   ```bash
   git clone https://github.com/RINAY112/sd-mhw1
   ```

2. ��������� ����������:  
   ```bash
   dotnet run --project MHW1
   ```

---

## �����

```bash
dotnet test
```