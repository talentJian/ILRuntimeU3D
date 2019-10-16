using System;
using System.Collections.Generic;
using System.Reflection;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Utils;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using UnityEngine;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

public class RectBinder: ValueTypeBinder<Rect>
{
    Vector2Binder vector2Binder;
    bool vector2BinderGot;

    Vector2Binder Vector2Binder
    {
        get
        {
            if (!vector2BinderGot)
            {
                vector2BinderGot = true;
                var vector3Type = CLRType.AppDomain.GetType(typeof(Vector2)) as CLRType;
                vector2Binder = vector3Type.ValueTypeBinder as Vector2Binder;
            }

            return vector2Binder;
        }
    }

    Vector3Binder vector3Binder;
    bool vector3BinderGot;

    Vector3Binder Vector3Binder
    {
        get
        {
            if (!vector3BinderGot)
            {
                vector3BinderGot = true;
                var vector3Type = CLRType.AppDomain.GetType(typeof(Vector3)) as CLRType;
                vector3Binder = vector3Type.ValueTypeBinder as Vector3Binder;
            }

            return vector3Binder;
        }
    }

    public override unsafe void CopyValueTypeToStack(ref Rect ins, StackObject* ptr, IList<object> mStack)
    {

        var v = ILIntepreter.Minus(ptr, 1);
        *(float*)&v->Value = ins.x;
        v = ILIntepreter.Minus(ptr, 2);
        *(float*)&v->Value = ins.y;
        v = ILIntepreter.Minus(ptr, 3);
        *(float*)&v->Value = ins.width;
        v = ILIntepreter.Minus(ptr, 4);
        *(float*)&v->Value = ins.height;
    }

    public override unsafe void AssignFromStack(ref Rect ins, StackObject* ptr, IList<object> mStack)
    {
        var v = ILIntepreter.Minus(ptr, 1);
        ins.x = *(float*)&v->Value;
        v = ILIntepreter.Minus(ptr, 2);
        ins.y = *(float*)&v->Value;
        v = ILIntepreter.Minus(ptr, 3);
        ins.width = *(float*)&v->Value;
        v = ILIntepreter.Minus(ptr, 4);
        ins.height = *(float*)&v->Value;

    }

    public override unsafe void RegisterCLRRedirection(AppDomain appdomain)
    {
        BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        MethodBase method;
        Type[] args;
        Type type = typeof(Rect);

        args = new Type[] { typeof(float), typeof(float), typeof(float),typeof(float) };
        method = type.GetConstructor(flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, NewRect);

        args = new Type[] { typeof(Rect), typeof(Rect) };
        method = type.GetMethod("op_Equality", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Rect_Equality);

        args = new Type[] { typeof(Vector3), typeof(Vector3) };
        method = type.GetMethod("op_Inequality", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Rect_Inequality);

        args = new Type[] { };
        method = type.GetMethod("get_x", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_X);

        args = new Type[] { typeof(System.Single) };
        method = type.GetMethod("set_x", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_X);

        args = new Type[] { };
        method = type.GetMethod("get_y", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_y);

        args = new Type[] { typeof(System.Single) };
        method = type.GetMethod("set_y", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_y);


        args = new Type[] { };
        method = type.GetMethod("get_width", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Widht);

        args = new Type[] { typeof(System.Single) };
        method = type.GetMethod("set_width", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_Width);

        args = new Type[] { };
        method = type.GetMethod("get_height", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Height);

        args = new Type[] {typeof(Vector2)};
        method = type.GetMethod("set_position", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_Position);

        args = new Type[] { };
        method = type.GetMethod("get_position", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Position);

        args = new Type[] { typeof(Vector2) };
        method = type.GetMethod("set_center", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_Center);

        args = new Type[] { };
        method = type.GetMethod("get_center", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Center);

        args = new Type[] { typeof(Vector2) };
        method = type.GetMethod("set_size", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_Size);

        args = new Type[] { };
        method = type.GetMethod("get_size", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Size);

        args = new Type[] { typeof(Vector2) };
        method = type.GetMethod("set_min", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_Min);

        args = new Type[] { };
        method = type.GetMethod("get_min", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Min);

        args = new Type[] { typeof(Vector2) };
        method = type.GetMethod("set_max", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Set_Max);

        args = new Type[] { };
        method = type.GetMethod("get_max", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Max);

        args = new Type[] { };
        method = type.GetMethod("get_zero", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Get_Zero);

        args = new Type[] { typeof(UnityEngine.Vector3) };
        method = type.GetMethod("Contains", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Contains_Vecotr3);

        args = new Type[] { typeof(UnityEngine.Vector2) };
        method = type.GetMethod("Contains", flag, null, args, null);
        appdomain.RegisterCLRMethodRedirection(method, Contains_Vector2);
    }

    private unsafe StackObject* Contains_Vecotr3(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 2);

        var ptr = ILIntepreter.Minus(esp, 1);

        Vector3 @point = new Vector3();
        Vector3Binder.ParseVector3(out @point, intp, ptr, mStack);


        ptr = ILIntepreter.Minus(esp, 2); 
        Rect mRect;
        ParseRect(out mRect,intp,ptr,mStack);
        var result = mRect.Contains(@point);

        ret->ObjectType = ObjectTypes.Integer;
        ret->Value = result ? 1 : 0;

        return ret + 1;
    }

    private unsafe StackObject* Contains_Vector2(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 2);

        var ptr = ILIntepreter.Minus(esp, 1);

        Vector2 @point = new Vector2();
        Vector2Binder.ParseVector2(out @point, intp, ptr, mStack);


        ptr = ILIntepreter.Minus(esp, 2);
        Rect mRect;
        ParseRect(out mRect, intp, ptr, mStack);
        var result = mRect.Contains(@point);

        ret->ObjectType = ObjectTypes.Integer;
        ret->Value = result ? 1 : 0;

        return ret + 1;
    }


    private unsafe StackObject* Get_Max(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);

        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);

        Vector2 res = rect.max;

        PushVector2(ref res, intp, ret, mStack);
        return ret + 1;
    }

    private unsafe StackObject* Set_Max(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Vector2 @value = new Vector2();
        Vector2Binder.ParseValue(ref @value, intp, ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.max = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_Min(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);

        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);

        Vector2 res = rect.min;

        PushVector2(ref res, intp, ret, mStack);
        return ret + 1;
    }

    private unsafe StackObject* Set_Min(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Vector2 @value = new Vector2();
        Vector2Binder.ParseValue(ref @value, intp, ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.min = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_Size(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);

        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);

        Vector2 res = rect.size;

        PushVector2(ref res, intp, ret, mStack);
        return ret + 1;
    }

    private unsafe StackObject* Set_Size(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Vector2 @value = new Vector2();
        Vector2Binder.ParseValue(ref @value, intp, ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.size = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_Center(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);

        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);

        Vector2 res = rect.center;

        PushVector2(ref res, intp, ret, mStack);
        return ret + 1;
    }

    private unsafe StackObject* Set_Center(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Vector2 @value = new Vector2();
        Vector2Binder.ParseValue(ref @value, intp, ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.center = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_Position(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);

        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);

        Vector2 res = rect.position;

        PushVector2(ref res, intp, ret, mStack);
        return ret + 1;
    }

    private unsafe StackObject* Set_Position(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Vector2 @value = new Vector2();
        Vector2Binder.ParseValue(ref @value,intp,ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.position = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }


    private unsafe StackObject* Set_y(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        System.Single @value = *(float*)&ptr->Value;
        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.y = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_y(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);
        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);
        float res = rect.y;

        ret->ObjectType = ObjectTypes.Float;
        *(float*)&ret->Value = res;
        return ret + 1;
    }

    private unsafe StackObject* Set_X(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        System.Single @value = *(float*)&ptr->Value;
        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.x = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_X(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);
        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);
        float res = rect.x;

        ret->ObjectType = ObjectTypes.Float;
        *(float*)&ret->Value = res;
        return ret + 1;
    }


    private unsafe StackObject* Get_Height(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);
        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);
        float res = rect.height;

        ret->ObjectType = ObjectTypes.Float;
        *(float*)&ret->Value = res;
        return ret + 1;
    }

    private unsafe StackObject* Set_Height(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        System.Single @value = *(float*)&ptr->Value;
        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);
        
        instance_of_this_method.height = @value;

        WriteBackValue(__domain,ptr,mStack,ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Set_Width(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = intp.AppDomain;
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        System.Single @value = *(float*)&ptr->Value;
        ptr = ILIntepreter.Minus(esp, 2);
        UnityEngine.Rect instance_of_this_method;
        ParseRect(out instance_of_this_method, intp, ptr, mStack);

        instance_of_this_method.width = @value;

        WriteBackValue(__domain, ptr, mStack, ref instance_of_this_method);
        return ret;
    }

    private unsafe StackObject* Get_Widht(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 1);
        var ptr = ILIntepreter.Minus(esp, 1);
        Rect rect;
        ParseRect(out rect, intp, ptr, mStack);
        float res = rect.width;

        ret->ObjectType = ObjectTypes.Float;
        *(float*) &ret->Value = res;
        return ret + 1;
    }

    private unsafe StackObject* Get_Zero(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = esp;
        var res = Rect.zero;
        PushRect(ref res, intp, ret, mStack);
        return ret + 1;
    }

    private unsafe StackObject* Rect_Equality(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Rect left, right;
        ParseRect(out right, intp, ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        ParseRect(out left, intp, ptr, mStack);

        var res = left == right;

        ret->ObjectType = ObjectTypes.Integer;
        ret->Value = res ? 1 : 0;
        return ret + 1;
    }
    private unsafe StackObject* Rect_Inequality(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isnewobj)
    {
        var ret = ILIntepreter.Minus(esp, 2);
        var ptr = ILIntepreter.Minus(esp, 1);

        Rect left, right;
        ParseRect(out right, intp, ptr, mStack);

        ptr = ILIntepreter.Minus(esp, 2);
        ParseRect(out left, intp, ptr, mStack);

        var res = left != right;

        ret->ObjectType = ObjectTypes.Integer;
        ret->Value = res ? 1 : 0;
        return ret + 1;
    }

    private unsafe StackObject* NewRect(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isNewObj)
    {
        StackObject* ret;
        if (isNewObj)
        {
            ret = ILIntepreter.Minus(esp, 2);
            Rect vec = new Rect();
            var ptr = ILIntepreter.Minus(esp, 1);
            vec.height = *(float*)&ptr->Value;
            ptr = ILIntepreter.Minus(esp, 2);
            vec.width = *(float*)&ptr->Value;
            ptr = ILIntepreter.Minus(esp, 3);
            vec.y = *(float*)&ptr->Value;
            ptr = ILIntepreter.Minus(esp, 4);
            vec.x = *(float*)&ptr->Value;

            PushRect(ref vec, intp, ptr, mStack);
        }
        else
        {
            ret = ILIntepreter.Minus(esp, 5);
            var instance = ILIntepreter.GetObjectAndResolveReference(ret);
            var dst = *(StackObject**)&instance->Value;
            var f = ILIntepreter.Minus(dst, 1);
            var v = ILIntepreter.Minus(esp, 4);
            *f = *v;

            f = ILIntepreter.Minus(dst, 2);
            v = ILIntepreter.Minus(esp, 3);
            *f = *v;

            f = ILIntepreter.Minus(dst, 3);
            v = ILIntepreter.Minus(esp, 3);
            *f = *v;

            f = ILIntepreter.Minus(dst, 4);
            v = ILIntepreter.Minus(esp, 1);
            *f = *v;
        }
        return ret;
    }

    private unsafe void PushRect(ref Rect vec, ILIntepreter intp, StackObject* ptr, IList<object> mStack)
    {
        intp.AllocValueType(ptr, CLRType);
        var dst = *((StackObject**)&ptr->Value);
        CopyValueTypeToStack(ref vec, dst, mStack);
    }
    private unsafe void PushVector2(ref Vector2 vec, ILIntepreter intp, StackObject* ptr, IList<object> mStack)
    {
        var binder = Vector2Binder;
        if (binder != null)
            binder.PushVector2(ref vec, intp, ptr, mStack);
        else
            ILIntepreter.PushObject(ptr, mStack, vec, true);
    }
    public static unsafe void ParseRect(out Rect vec, ILIntepreter intp, StackObject* ptr, IList<object> mStack)
    {
        vec = new Rect();
        var a = ILIntepreter.GetObjectAndResolveReference(ptr);
        if (a->ObjectType == ObjectTypes.ValueTypeObjectReference)
        {
            var src = *(StackObject**)&a->Value;
            vec.x = *(float*)&ILIntepreter.Minus(src, 1)->Value;
            vec.y = *(float*)&ILIntepreter.Minus(src, 2)->Value;
            vec.width = *(float*)&ILIntepreter.Minus(src, 3)->Value;
            vec.height = *(float*)&ILIntepreter.Minus(src, 4)->Value;
            intp.FreeStackValueType(ptr);
        }
        else
        {
            vec = (Rect)StackObject.ToObject(a, intp.AppDomain, mStack);
            intp.Free(ptr);
        }
    }
}
