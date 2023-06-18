//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0add4890-78ad-4bff-b31a-99dc0e958212"",
            ""actions"": [
                {
                    ""name"": ""Built"",
                    ""type"": ""Button"",
                    ""id"": ""42ecee98-831e-48ba-a923-5a52d1fa38f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelBuilt"",
                    ""type"": ""Button"",
                    ""id"": ""3ee2feee-71df-4433-ba69-9141ede50f0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""1be33b17-5629-4fce-a442-20399e2ea58d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SettingsMenu"",
                    ""type"": ""Button"",
                    ""id"": ""21419a8e-76c5-46fb-a8d8-80fd9df9b0be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""caaedf8f-9926-4f10-a6b2-85994c48f553"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Built"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9145c3d-62af-42e5-a4a3-65fd0707c3bc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelBuilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a1e0f7e-dbee-42f2-8970-79c7f526f2bb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c3e16bb-f7ff-4968-8aa9-146f377106dd"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SettingsMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""7bbf68a7-7cab-4301-b9a8-544f87752194"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ad3c6c5a-df2d-4de8-950f-928688cab871"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""202c9bf6-bef6-4137-a347-e31c5476ee32"",
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
                    ""id"": ""d1b9a3fe-69f8-43b9-acc7-35cf198d7eb3"",
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
                    ""id"": ""e40d54b8-c42d-4b86-904a-1f5a17d35ac0"",
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
                    ""id"": ""2be25c34-99cc-47b7-a197-50862ed46afb"",
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
                    ""id"": ""716be664-3942-4b17-a8ac-9fdb88a944a0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""ab2389ec-c260-4662-9e9b-7774fa1750b8"",
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
                    ""id"": ""41b23c47-9711-46d8-b657-9ad84e8cf5d1"",
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
                    ""id"": ""3f19323f-3948-453e-94d4-2dbbb5321b7b"",
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
                    ""id"": ""af7a6b6d-6697-40aa-b0ec-35992be3beac"",
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
                    ""id"": ""79e4e2cb-1b7a-4ec6-88c8-1434c093c659"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Built = m_Player.FindAction("Built", throwIfNotFound: true);
        m_Player_CancelBuilt = m_Player.FindAction("CancelBuilt", throwIfNotFound: true);
        m_Player_PauseMenu = m_Player.FindAction("PauseMenu", throwIfNotFound: true);
        m_Player_SettingsMenu = m_Player.FindAction("SettingsMenu", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Move = m_Mouse.FindAction("Move", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Built;
    private readonly InputAction m_Player_CancelBuilt;
    private readonly InputAction m_Player_PauseMenu;
    private readonly InputAction m_Player_SettingsMenu;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Built => m_Wrapper.m_Player_Built;
        public InputAction @CancelBuilt => m_Wrapper.m_Player_CancelBuilt;
        public InputAction @PauseMenu => m_Wrapper.m_Player_PauseMenu;
        public InputAction @SettingsMenu => m_Wrapper.m_Player_SettingsMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Built.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuilt;
                @Built.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuilt;
                @Built.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuilt;
                @CancelBuilt.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelBuilt;
                @CancelBuilt.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelBuilt;
                @CancelBuilt.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelBuilt;
                @PauseMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @SettingsMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSettingsMenu;
                @SettingsMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSettingsMenu;
                @SettingsMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSettingsMenu;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Built.started += instance.OnBuilt;
                @Built.performed += instance.OnBuilt;
                @Built.canceled += instance.OnBuilt;
                @CancelBuilt.started += instance.OnCancelBuilt;
                @CancelBuilt.performed += instance.OnCancelBuilt;
                @CancelBuilt.canceled += instance.OnCancelBuilt;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @SettingsMenu.started += instance.OnSettingsMenu;
                @SettingsMenu.performed += instance.OnSettingsMenu;
                @SettingsMenu.canceled += instance.OnSettingsMenu;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Move;
    public struct MouseActions
    {
        private @PlayerInputActions m_Wrapper;
        public MouseActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Mouse_Move;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IPlayerActions
    {
        void OnBuilt(InputAction.CallbackContext context);
        void OnCancelBuilt(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnSettingsMenu(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}