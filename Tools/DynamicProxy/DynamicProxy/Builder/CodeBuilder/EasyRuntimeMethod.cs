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

	using Castle.DynamicProxy.Builder.CodeBuilder.SimpleAST;
	using Castle.DynamicProxy.Builder.CodeBuilder.Utils;

	/// <summary>
	/// Summary description for EasyRuntimeMethod.
	/// </summary>
	public class EasyRuntimeMethod : EasyMethod
	{
		public EasyRuntimeMethod(AbstractEasyType maintype, string name, 
			ReturnReferenceExpression returnRef, ArgumentReference[] arguments)
		{
			MethodAttributes atts = MethodAttributes.HideBySig|MethodAttributes.Public|MethodAttributes.Virtual;
			Type[] args = ArgumentsUtil.InitializeAndConvert( arguments );

			m_builder = maintype.TypeBuilder.DefineMethod(
				name, atts, returnRef.Type, args);
			m_builder.SetImplementationFlags(
				MethodImplAttributes.Runtime|MethodImplAttributes.Managed);
		}

		public override void Generate()
		{
			
		}

		public override void EnsureValidCodeBlock()
		{
			
		}
	}
}
