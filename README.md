# Behavior Pattern

아이템, 몬스터, 캐릭터 등 다양한 고유 효과를 구현하기 위한 디자인 패턴입니다.

`Behavior<T>` 클래스를 상속하며

키를 통해 클래스를 가져올 수 있고, 클래스 이름이 키가 됩니다.

클래스는 처음으로 가져올 때 생성합니다.

## 예제
```
public enum ItemGrade
{
  None,
  Normal,
  Rare,
  Unique,
  Legendary,
  Myth,
}

public enum ItemType
{
  None,
  Weapon,
  Armor
}

public abstract class ItemBehavior : Behavior<ItemBehavior>
{
  public abstract ItemGrade ItemGrade { get; }
  public abstract ItemType ItemType { get; }

  public abstract void OnUse();
  public virtual void OnGet() { }
  
  public string Name => Key
}
```

반드시 설정해야 하는 멤버는 `abstract` 으로 구현합니다.

설정하지 않아도 되거나 기본값을 지정할 멤버는 `virual` 로 구현합니다.

변경되지 않을 멤버는 키워드 없이 구현합니다.

```
public class Item_Sword : ItemBehavior
{
  public override ItemGrade ItemGrade { get; } = ItemGrade.Normal;
  public override ItemType ItemType { get; } = ItemType.Weapon;

  public override void OnUse()
  {
    //사용 시 효과
  }
  
  public override void OnGet()
  {
    //획득 시 효과
  }
}
```
```
void Start()
{
  ItemBehavior Sword = ItemBehavior.Get<Item_Sword>();
}
```

예제의 아이템은 `ItemBehavior.Get<>()` 함수로 가져올 수 있습니다.
