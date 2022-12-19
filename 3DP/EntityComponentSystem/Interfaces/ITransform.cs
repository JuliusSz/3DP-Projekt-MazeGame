using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityComponentSystem
{
    public interface ITransform
    {
		// Matrix that transforms a point from local space into world space
        Matrix LocalToWorldMatrix { get; }
		
		// Matrix that transforms a point from world space into local space
		Matrix WorldToLocalMatrix { get; } 

		// The scale of the transform relative to the GameObjects parent
        Vector3 LocalScale { get; set; }
		
		// The global scale of the object
		// Please note that if you have a parent transform with scale and a 
		// child that is arbitrarily rotated, the scale will be skewed
        Vector3 Scale { get; set; }

		// Position of the transform relative to the parent transform
        Vector3 LocalPosition { get; set; }
		
		// The world space position of the Transform
        Vector3 Position { get; set; }

		// Returns a normalized vector representing the blue axis of the transform in world space
        Vector3 Forward { get; set; }

		// Opposite direction of forward
        Vector3 Backward { get; set; }

		// The green axis of the transform in world space
        Vector3 Up { get; set; }

		// Opposite direction of up
        Vector3 Down { get; set; }

		// The red axis of the transform in world space
        Vector3 Right { get; set; }

		// // Opposite direction of right
        Vector3 Left { get; set; }

		// The rotation of the transform relative to the transform rotation of the parent
        Quaternion LocalRotation { get; set; }
		
		// A Quaternion that stores the rotation of the Transform in world space
        Quaternion Rotation { get; set; }

		// The rotation of the transform relative to the transform rotation of the parent
        Matrix LocalRotationMatrix { get; set; }
		
		// A Matrix that stores the rotation of the Transform in world space
        Matrix RotationMatrix { get; set; }

		// The rotation as Euler angles in degrees relative to the parent transform's rotation
        Vector3 LocalEulerAngles { get; set; }

		// The rotation as Euler angles in degrees
        Vector3 EulerAngles { get; set; }

        // Transforms direction from local space to world space.
        // This operation is not affected by scale or position of the transform.
        // The returned vector has the same length as direction.
        Vector3 TransformDirection(Vector3 direction);
        Vector3 TransformDirection(float x, float y, float z);

        // Transforms a direction from world space to local space. 
        // The opposite of Transform.TransformDirection.
        // This operation is unaffected by scale.
        Vector3 InverseTransformDirection(Vector3 direction);
        Vector3 InverseTransformDirection(float x, float y, float z);

        // Transforms position from local space to world space.
        // Note that the returned position is affected by scale.
        Vector3 TransformPoint(Vector3 position);
        Vector3 TransformPoint(float x, float y, float z);

        // Transforms position from world space to local space.
        // This function is essentially the opposite of Transform.TransformPoint, 
        // which is used to convert from local to world space.
        // Note that the returned position is affected by scale.
        Vector3 InverseTransformPoint(Vector3 position);
        Vector3 InverseTransformPoint(float x, float y, float z);

        // Transforms vector from local space to world space.
        // This operation is not affected by position of the transform, 
        // but it is affected by scale.The returned vector may have a different 
        // length than vector.
        Vector3 TransformVector(Vector3 vector);
        Vector3 TransformVector(float x, float y, float z);

        // Transforms a vector from world space to local space.
        // The opposite of Transform.TransformVector.
        // This operation is affected by scale.
        Vector3 InverseTransformVector(Vector3 vector);
        Vector3 InverseTransformVector(float x, float y, float z);

        // Rotates the GameObject so the forward vector points 
        // at target's current position.
        void LookAt(Transform target);

        // Rotates the GameObject around it's Pivot Point
        // If relativeTo is not specified or set to Space.Self the rotation is applied 
        // around the GameObject's local axes. If relativeTo is set to Space.World 
        // the rotation is applied around the world x, y, z axes.
        void Rotate(Vector3 eulers, Space relativeTo = Space.Self);
        void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo = Space.Self);
        void Rotate(Vector3 axis, float angle, Space relativeTo = Space.Self);

        // Rotates the transform about axis passing through point in world 
        // coordinates by angle degrees. This modifies both the position and 
        // the rotation of the transform.
        void RotateAround(Vector3 point, Vector3 axis, float angle);

        // Sets the world space position and rotation of the Transform component.
        void SetPositionAndRotation(Vector3 position, Quaternion rotation);
		
		// Sets the position and rotation of the Transform component in local space 
		// (i.e. relative to its parent transform). When setting both the position and 
		// rotation of a transform, calling this method is slightly more efficient 
		// than assigning to localPosition and localRotation individually.
		// If the transform has no parent, then calling this is equivalent to calling 
		// SetPositionAndRotation.
		void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation);

        // Moves the transform in the direction and distance of translation.
        // If relativeTo is left out or set to Space.Self the movement is applied 
        // relative to the transform's local axes. (the x, y and z axes shown when 
        // selecting the object inside the Scene View.) If relativeTo is Space.World 
        // the movement is applied relative to the world coordinate system.
        void Translate(float x, float y, float z, Space relativeTo = Space.Self);
        void Translate(Vector3 translation, Space relativeTo = Space.Self);
		
		
		// The number of children the parent Transform has
		int childCount {get; }

		// The parent of the transform.
		// Changing the parent will modify the parent-relative position, 
		// scale and rotation but keep the world space position, rotation 
		// and scale the same.
		Transform parent {get; set;}
		
		// Returns the topmost transform in the hierarchy.
		// This never returns null, if this Transform doesn't have a parent 
		// it returns itself
		Transform root {get;}
		
		// Unparents all children.
		// Useful if you want to destroy the root of a hierarchy without 
		// destroying the children.
		void DetachChildren();

		// Finds a child by name n and returns it.
		// If no child with name n can be found, null is returned. 
		// Note: Find does not perform a recursive descend down a Transform hierarchy.
		// Note: Find can find transform of disabled GameObject.
		Transform Find(string name);

		// Returns a transform child by index.
		// If the transform has no child, or the index argument has a value 
		// greater than the number of children then an error will be 
		// generated. The number of children can be provided by childCount.
		Transform GetChild(int index);


		// Use this to return the sibling index of the GameObject. 
		// If a GameObject shares a parent with other GameObjects and are 
		// on the same level (i.e. they share the same direct parent), 
		// these GameObjects are known as siblings. The sibling index shows 
		// where each GameObject sits in this sibling hierarchy.
		// Use GetSiblingIndex to find out the GameObject’s place in 
		// this hierarchy. When the sibling index of a GameObject is changed, 
		// its order in the Hierarchy window will also change. This is useful 
		// if you are intentionally ordering the children of a GameObject 
		// such as when using Layout Group components.
		int GetSiblingIndex();
		
		// Returns a boolean value that indicates whether the transform is a 
		// child of a given transform. true if this transform is a child, 
		// deep child (child of a child) or identical to this transform, 
		// otherwise false.
		bool IsChildOf(Transform parent);
		
		// Move the transform to the start of the local transform list
		void SetAsFirstSibling();

		// Move the transform to the end of the local transform list
		void SetAsLastSibling();

		// Use this to change the sibling index of the GameObject. 
		// If a GameObject shares a parent with other GameObjects 
		// and are on the same level (i.e. they share the same direct 
		// parent), these GameObjects are known as siblings. The 
		// sibling index shows where each GameObject sits in this 
		// sibling hierarchy.Use SetSiblingIndex to change the 
		// GameObject’s place in this hierarchy. When the sibling 
		// index of a GameObject is changed, its order in the Hierarchy
		// window will also change. This is useful if you are 
		// intentionally ordering the children of a GameObject such 
		// as when using Layout Group components.
		void SetSiblingIndex(int index);
		
		// Set the parent of the transform
		// This method is the same as the parent property except that 
		// it also lets the Transform keep its local orientation rather 
		// than its global orientation. This means for example, if 
		// the GameObject was previously next to its parent, setting 
		// worldPositionStays to false will move the GameObject to be 
		// positioned next to its new parent in the same way.
		// The default value of worldPositionStays argument is true.
		void SetParent(Transform p);
		void SetParent(Transform parent, bool worldPositionStays);
    }
}
