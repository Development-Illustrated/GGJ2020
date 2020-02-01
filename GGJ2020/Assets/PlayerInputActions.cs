// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""ff0fc271-7f25-4841-8edb-9bb1f8f9d657"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a35c5c71-1283-48bb-99b0-f12c0fd30fe0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapons"",
                    ""type"": ""Button"",
                    ""id"": ""d3398c46-9080-4b29-b510-0f435f071b2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapons1"",
                    ""type"": ""Button"",
                    ""id"": ""9b7eefcf-cba8-411f-a941-4d91fec9d386"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapons2"",
                    ""type"": ""Button"",
                    ""id"": ""7496761a-a64f-4e5b-914a-25febf45ee70"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""982ea8a4-4c4d-43b7-b61b-448189ffb3b8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a8b600b8-312d-49cd-9aab-1cc50184736d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""797c2649-68a5-4f89-8b27-62d2607e361b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dbc84bd4-8eb7-4ec1-a240-5881cae2ccb7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""60c88050-5501-4036-aafe-a3ff30f7072b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ARROWS"",
                    ""id"": ""5acf01a7-dc1f-4fa1-8f86-a43249e2142c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2ad24785-87de-4d2c-9cd5-3222563beeec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""23dd99a0-56b9-45dd-8da0-403a183de864"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3da0b8f2-c7de-4a34-b8ed-cbc1a32ff5c0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee2a2be6-2646-4206-9bfd-b91653991adb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c221f85f-7108-4048-9f48-d01b2cc8c9d5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7b47831-439b-40c5-a1b3-bc8d01f2a756"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapons2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bb6df57-29ba-44ce-9a84-f774eaace6a8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapons1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Move = m_PlayerActions.FindAction("Move", throwIfNotFound: true);
        m_PlayerActions_Weapons = m_PlayerActions.FindAction("Weapons", throwIfNotFound: true);
        m_PlayerActions_Weapons1 = m_PlayerActions.FindAction("Weapons1", throwIfNotFound: true);
        m_PlayerActions_Weapons2 = m_PlayerActions.FindAction("Weapons2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Move;
    private readonly InputAction m_PlayerActions_Weapons;
    private readonly InputAction m_PlayerActions_Weapons1;
    private readonly InputAction m_PlayerActions_Weapons2;
    public struct PlayerActionsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerActions_Move;
        public InputAction @Weapons => m_Wrapper.m_PlayerActions_Weapons;
        public InputAction @Weapons1 => m_Wrapper.m_PlayerActions_Weapons1;
        public InputAction @Weapons2 => m_Wrapper.m_PlayerActions_Weapons2;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Weapons.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons;
                @Weapons.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons;
                @Weapons.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons;
                @Weapons1.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons1;
                @Weapons1.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons1;
                @Weapons1.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons1;
                @Weapons2.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons2;
                @Weapons2.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons2;
                @Weapons2.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeapons2;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Weapons.started += instance.OnWeapons;
                @Weapons.performed += instance.OnWeapons;
                @Weapons.canceled += instance.OnWeapons;
                @Weapons1.started += instance.OnWeapons1;
                @Weapons1.performed += instance.OnWeapons1;
                @Weapons1.canceled += instance.OnWeapons1;
                @Weapons2.started += instance.OnWeapons2;
                @Weapons2.performed += instance.OnWeapons2;
                @Weapons2.canceled += instance.OnWeapons2;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface IPlayerActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnWeapons(InputAction.CallbackContext context);
        void OnWeapons1(InputAction.CallbackContext context);
        void OnWeapons2(InputAction.CallbackContext context);
    }
}
