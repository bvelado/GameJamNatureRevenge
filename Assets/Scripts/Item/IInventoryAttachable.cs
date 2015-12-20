using UnityEngine;
using System.Collections;

public interface IInventoryAttachable {

    void Attach(Inventory inventory);

    void Detach();
}
