// GENERATED AUTOMATICALLY FROM 'Assets/Scrips/VRControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VRControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VRControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VRControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""75601295-220f-4ebc-828b-e48db4e44398"",
            ""actions"": [
                {
                    ""name"": ""VRClick"",
                    ""type"": ""Value"",
                    ""id"": ""a0f91a80-b229-40a8-98fb-5596d3302f32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8af353c4-2b59-45f7-ac96-07dd6f55f2a7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""VRClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a5c7fa5-19ba-4abb-8a11-884e3128277f"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""VRClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Android"",
            ""bindingGroup"": ""Android"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_VRClick = m_Gameplay.FindAction("VRClick", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_VRClick;
    public struct GameplayActions
    {
        private @VRControls m_Wrapper;
        public GameplayActions(@VRControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @VRClick => m_Wrapper.m_Gameplay_VRClick;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @VRClick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVRClick;
                @VRClick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVRClick;
                @VRClick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVRClick;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @VRClick.started += instance.OnVRClick;
                @VRClick.performed += instance.OnVRClick;
                @VRClick.canceled += instance.OnVRClick;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    private int m_AndroidSchemeIndex = -1;
    public InputControlScheme AndroidScheme
    {
        get
        {
            if (m_AndroidSchemeIndex == -1) m_AndroidSchemeIndex = asset.FindControlSchemeIndex("Android");
            return asset.controlSchemes[m_AndroidSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnVRClick(InputAction.CallbackContext context);
    }
}
