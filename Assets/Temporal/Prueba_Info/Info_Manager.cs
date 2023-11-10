
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Info_Manager : MonoBehaviour
{
    [SerializeField] private Cam_Settings[] settings;
    private int settings_Index; //0 = inicio; 1 = Explicacion SSEM; 2 = Despiece; 3 = Expansion; 4 = Magnetismo; 5 = Explicacion Malla; 6 = Magnetismo_Malla; 7 = Material; 8 = Magnetismo Material 
    [SerializeField] private float Time_Between_transitions;
    private Camera cam;
    bool Active = true;
    bool OBJ_Orientation,Regression;
    [SerializeField] private GameObject Bloque_01, Bloque_02, Tapa_01, Tapa_02, Carcasa, Pantalla, Manivela, Bloque_Arriba, Cilindro, Base_Pilar, Pilar, Malla_01, Malla_02, Material;
    [SerializeField] private CanvasGroup[] Paneles;
    [SerializeField] private Vector3 Bloque_01_Final_Pos, Bloque_02_Final_Pos, Tapa_01_Final_Pos, Tapa_02_Final_Pos, Carcasa_Final_Pos, Pantalla_Final_Pos, Manivela_Final_Pos, Bloque_Arriba_Final_Pos, Cilindro_Final_Pos, Cilindro_Final_Scale, Base_Pilar_final_Scale, Pilar_Final_Scale, Material_Final_Scale; 
    private Vector3 Bloque_01_Init_Pos, Bloque_02_Init_Pos, Tapa_01_Init_Pos, Tapa_02_Init_Pos, Carcasa_Init_Pos, Pantalla_Init_Pos, Manivela_Init_Pos, Bloque_Arriba_Init_Pos, Cilindro_Init_Pos, Cilindro_Init_Scale, Base_Pilar_Init_Scale, Pilar_Init_Scale, Material_Init_Scale;
    private TweenCallback call;
    void Start()
    {
        Set_Cam();
        Set_OBJ_Pos();

    }

    private void Set_Cam()
    {
        cam = Camera.main;
        settings_Index = 0;
        cam.gameObject.transform.position = settings[settings_Index].pos;
        cam.gameObject.transform.rotation = Quaternion.Euler(settings[settings_Index].rot.x,settings[settings_Index].rot.y,settings[settings_Index].rot.z);
        cam.orthographicSize = settings[settings_Index].size;
    }

    private void Set_OBJ_Pos()
    {
        Bloque_01_Init_Pos = Bloque_01.transform.position;
        Bloque_02_Init_Pos = Bloque_02.transform.position;
        Tapa_01_Init_Pos = Tapa_01.transform.position;
        Tapa_02_Init_Pos = Tapa_02.transform.position;
        Carcasa_Init_Pos = Carcasa.transform.position;
        Pantalla_Init_Pos = Pantalla.transform.position;
        Manivela_Init_Pos = Manivela.transform.position;
        Bloque_Arriba_Init_Pos = Bloque_Arriba.transform.position;
        Cilindro_Init_Pos = Cilindro.transform.position;
        Cilindro_Init_Scale = Cilindro.transform.localScale;
        Base_Pilar_Init_Scale = Base_Pilar.transform.localScale;
        Pilar_Init_Scale = Pilar.transform.localScale;
    }

    public void Move_Foward()
    {
        if(!Active)return;
        Activation();
        settings_Index++;
        Debug.Log(settings_Index);
        Check_Continuous();
    }

    public void Move_Backwards()
    {
        if(!Active|| settings_Index==0) return;
        Activation();
        settings_Index--;
        Debug.Log(settings_Index);
        Check_Regresion();
    }

    private void Camera_Movement()
    {
        if(settings_Index == 2 && Regression)
        {
            Regression = false;
            OBJ_Orientation = true;
            Move_Cam(Despiece);
            return;
        }
        if(call != null)
        {
            Move_Cam(call);
            call = null;
            return;
        }
        Move_Cam(Panel_Activation);
    }

    private void Move_Cam(TweenCallback tween)
    {
        cam.gameObject.transform.DOMove(settings[settings_Index].pos,Time_Between_transitions);
        cam.gameObject.transform.DORotate(settings[settings_Index].rot,Time_Between_transitions);
        cam.DOOrthoSize(settings[settings_Index].size,Time_Between_transitions).OnComplete(tween);
    }

    private void Activation()
    {
        Active =!Active;
    }

    private void Despiece()
    {
        if(Regression)
        {
            Move_OBJ_Parts(Camera_Movement);
        }
        else
        {
            if(call != null)
            {
                Move_OBJ_Parts(call);
                call = null;
                return;
            }
            Move_OBJ_Parts(Panel_Activation);
        }
    }

    private void Move_OBJ_Parts(TweenCallback tween)
    {
        if(OBJ_Orientation)
        {
            Bloque_01.transform.DOLocalMove(Bloque_01_Final_Pos,Time_Between_transitions);
            Bloque_02.transform.DOLocalMove(Bloque_02_Final_Pos,Time_Between_transitions);
            Tapa_01.transform.DOLocalMove(Tapa_01_Final_Pos,Time_Between_transitions);
            Tapa_02.transform.DOLocalMove(Tapa_02_Final_Pos,Time_Between_transitions);
            Carcasa.transform.DOLocalMove(Carcasa_Final_Pos,Time_Between_transitions);
            Pantalla.transform.DOLocalMove(Pantalla_Final_Pos,Time_Between_transitions);
            Manivela.transform.DOLocalMove(Manivela_Final_Pos,Time_Between_transitions).OnComplete(tween);
        }
        else
        {
            Bloque_01.transform.DOMove(Bloque_01_Init_Pos,Time_Between_transitions);
            Bloque_02.transform.DOMove(Bloque_02_Init_Pos,Time_Between_transitions);
            Tapa_01.transform.DOMove(Tapa_01_Init_Pos,Time_Between_transitions);
            Tapa_02.transform.DOMove(Tapa_02_Init_Pos,Time_Between_transitions);
            Carcasa.transform.DOMove(Carcasa_Init_Pos,Time_Between_transitions);
            Pantalla.transform.DOMove(Pantalla_Init_Pos,Time_Between_transitions);
            Manivela.transform.DOMove(Manivela_Init_Pos,Time_Between_transitions).OnComplete(tween);
        }
    }

    private void Deploy()
    {
        if(Regression)
        {
            Scale_Block(Camera_Movement);
        }
        else
        {
            Scale_Block(Panel_Activation);
        }
    }

    private void Scale_Block(TweenCallback tween)
    {
        if(OBJ_Orientation)
        {
            Bloque_Arriba.transform.DOLocalMove(Bloque_Arriba_Final_Pos,Time_Between_transitions);
            Cilindro.transform.DOLocalMove(Cilindro_Final_Pos,Time_Between_transitions);
            Cilindro.transform.DOScale(Cilindro_Final_Scale,Time_Between_transitions).OnComplete(tween);
        }
        else
        {
            Bloque_Arriba.transform.DOMove(Bloque_Arriba_Init_Pos,Time_Between_transitions);
            Cilindro.transform.DOMove(Cilindro_Init_Pos,Time_Between_transitions);
            Cilindro.transform.DOScale(Cilindro_Init_Scale,Time_Between_transitions).OnComplete(tween);
        }
    }
    private void Scale_Pilar_Base()
    {
        if(OBJ_Orientation)
        {
            Pilar.transform.DOScale(Pilar_Final_Scale,Time_Between_transitions);
            Base_Pilar.transform.DOScale(Base_Pilar_final_Scale,Time_Between_transitions).OnComplete(Panel_Activation);
        }
        else
        {
            Pilar.transform.DOScale(Pilar_Init_Scale,Time_Between_transitions);
            Base_Pilar.transform.DOScale(Base_Pilar_Init_Scale,Time_Between_transitions).OnComplete(Panel_Activation);
        }
    }

    private void Scale_Mat(TweenCallback tween)
    {
        if(OBJ_Orientation)
        {
            Material.transform.DOScale(Material_Final_Scale,Time_Between_transitions).OnComplete(tween);
        }
        else
        {
            Material.transform.DOScale(Material_Init_Scale,Time_Between_transitions).OnComplete(tween);
        }

    }
    
    private void Mat()
    {
        if(Regression)
        {
            Scale_Mat(Camera_Movement);
        }
        else
        {
            Scale_Mat(Panel_Activation);
        }
    }
    private void OBJ_Close()
    {
        OBJ_Orientation = true;
        Move_Cam(Deploy);
    }

    private void Panel_Activation()
    {
        Paneles[settings_Index].DOFade(1,Time_Between_transitions-1).OnComplete(Activation);
    }

    private void Panel_Activation(TweenCallback tween)
    {
        int i = Regression? settings_Index+1: settings_Index-1;
        Paneles[i].DOFade(0,Time_Between_transitions-1).OnComplete(tween);
    }

    private void Check_Continuous()
    {
        Regression = false;
        call = null;
        if(settings_Index == 1)
        {
            Panel_Activation(Camera_Movement);
        }
        else if(settings_Index == 2)
        {
            OBJ_Orientation = true;
            call = Despiece;
            Panel_Activation(Camera_Movement);
        }
        else if (settings_Index == 3)
        {
            OBJ_Orientation = false;
            call = OBJ_Close;
            Panel_Activation(Despiece);
        }
        else if(settings_Index == 4)
        {
            OBJ_Orientation = true;
            Panel_Activation(Scale_Pilar_Base);
        }
        else if (settings_Index == 5)
        {
            Malla_01.SetActive(true);
            Panel_Activation(Camera_Movement);
        }
        else if(settings_Index == 6)
        {
            Malla_01.SetActive(false);
            Malla_02.SetActive(true);
            Panel_Activation(Camera_Movement);
        }
        else if(settings_Index == 7)
        {
            OBJ_Orientation = true;
            call = Mat;
            Panel_Activation(Camera_Movement);
        }
        else if(settings_Index == 8)
        {
            Panel_Activation(Camera_Movement);
        }
    }

    private void Check_Regresion()
    {
        Regression = true;
        call = null;
        if(settings_Index == 0)
        {
            Panel_Activation(Camera_Movement);
        }
        else if(settings_Index == 1)
        {
            OBJ_Orientation=false;
            Panel_Activation(Despiece);
        }
        else if(settings_Index == 2)
        {
            OBJ_Orientation=false;
            Panel_Activation(Deploy);
        }
        else if(settings_Index == 3)
        {
            OBJ_Orientation=false;
            Panel_Activation(Scale_Pilar_Base);
        }
        else if(settings_Index==4)
        {
            Panel_Activation(Camera_Movement);
            Malla_01.SetActive(false);
        }
        else if(settings_Index == 5)
        {
            Panel_Activation(Camera_Movement);
            Malla_02.SetActive(false);
            Malla_01.SetActive(true);
        }
        else if(settings_Index == 6)
        {
            OBJ_Orientation = false;
            Panel_Activation(Mat);
        }
        else if (settings_Index == 7)
        {
            Panel_Activation(Camera_Movement);
        }
    }
}

[System.Serializable]
public class Cam_Settings
{
    public Vector3 pos;
    public Vector3 rot;
    public float size;
}
