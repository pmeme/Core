using Castle.DynamicProxy.Builder.CodeBuilder.SimpleAST;
// Copyright 2004 DigitalCraftsmen - http://www.digitalcraftsmen.com.br/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.DynamicProxy.Builder.CodeBuilder
{
	using System;
	using System.Reflection;
	using System.Reflection.Emit;

	/// <summary>
	/// Summary description for ConstructorCodeBuilder.
	/// </summary>
	public class ConstructorCodeBuilder : AbstractCodeBuilder
	{
		private Type m_baseType;

		public ConstructorCodeBuilder( Type baseType, ILGenerator generator ) : base(generator)
		{
			m_baseType = baseType;
		}

		public void InvokeBaseConstructor()
		{
			InvokeBaseConstructor( ObtainAvailableConstructor() );
		}

//		public void InvokeBaseConstructor( ConstructorMethodReference constructor )
//		{
//			
//		}

		internal void InvokeBaseConstructor( ConstructorInfo constructor )
		{
			AddStatement( 
				new ExpressionStatement( 
					new ConstructorInvocationExpression(constructor) ) );
//			base.CallNonVirtual( constructor );
		}

		internal ConstructorInfo ObtainAvailableConstructor()
		{
			return m_baseType.GetConstructor(
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
				null, new Type[0], null);
		}
	}
}
