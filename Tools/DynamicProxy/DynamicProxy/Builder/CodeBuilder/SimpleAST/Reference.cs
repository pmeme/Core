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

namespace Castle.DynamicProxy.Builder.CodeBuilder.SimpleAST
{
	using System;
	using System.Reflection.Emit;

	/// <summary>
	/// Summary description for Reference.
	/// </summary>
	public abstract class Reference
	{
		private Reference m_owner = SelfReference.Self;

		public Reference()
		{
		}

		public Reference( Reference owner )
		{
			m_owner = owner;
		}

		public Reference OwnerReference
		{
			get { return m_owner; }
			set { m_owner = value; }
		}

		public virtual Expression ToExpression()
		{
			return new ReferenceExpression(this);
		}

		public virtual void Generate(ILGenerator gen)
		{
		}

		public abstract void LoadReference(ILGenerator gen);

		public abstract void StoreReference(ILGenerator gen);
	}
}
