using UnityEngine;
using System.Collections;

[System.Serializable]
public enum Direction {
    north, east, south, west
}

[System.Serializable]
public struct IntVector3 {
	public int x, y, z;

	public IntVector3 (int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public override bool Equals(object obj)
	{
		return (x == ((IntVector3)obj).x && (y == ((IntVector3)obj).y) && (z == ((IntVector3)obj).z));
	}
	public override int GetHashCode()
	{
		return z.GetHashCode() * 10000 + y.GetHashCode() * 100 + x.GetHashCode();
	}

	static public explicit operator Vector3(IntVector3 intVec3)
	{
		return new Vector3(intVec3.x, intVec3.y, intVec3.z);
	}

	public static IntVector3 operator +(IntVector3 a, IntVector3 b)
	{
		return new IntVector3(a.x + b.x, a.y + b.y, a.z + b.z);
	}
	public static IntVector3 operator -(IntVector3 a, IntVector3 b)
	{
		return new IntVector3(a.x - b.x, a.y - b.y, a.z - b.z);
	}
	public static bool operator ==(IntVector3 a, IntVector3 b)
	{
		return (a.x == b.x && a.y == b.y && a.z == b.z);
	}
	public static bool operator !=(IntVector3 a, IntVector3 b)
	{
		return !(a.x == b.x && a.y == b.y && a.z == b.z);
	}

    //public static int ManDist(IntVector3 a, IntVector3 b) {
    //    return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    //}

    public static IntVector3 zero =    new IntVector3(0, 0, 0);
	public static IntVector3 right =   new IntVector3(1, 0, 0);
	public static IntVector3 left =    new IntVector3(-1, 0, 0);
	public static IntVector3 forward = new IntVector3(0, 0, 1);
	public static IntVector3 back =    new IntVector3(0, 0, -1);
	public static IntVector3 up   =    new IntVector3(0, 1, 0);
	public static IntVector3 down =    new IntVector3(0, -1, 0);
	public static IntVector3 one =     new IntVector3(1, 1, 1);

	public static IntVector3[] directions = {IntVector3.forward, IntVector3.right, IntVector3.back, IntVector3.left };

    public static IntVector3 fromVector3(Vector3 v)
    {
        return new IntVector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
    }

    public override string ToString() {
        return "(" + x.ToString() + "," +y.ToString() + "," + z.ToString() + ")";
    }

	public static Quaternion RotationFromDir(IntVector3 dir) {
		return Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
	}
}
