// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#pragma warning disable CS0168, RCS1002, RCS1049, RCS1118, RCS1176, RCS1187

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roslynator.CSharp.Analyzers.Test
{
    internal static class ReduceIfNesting
    {
        private static readonly bool _condition;

        private static void Foo()
        {
            if (_condition)
            {
                Foo();

                if (!_condition)
                {
                    Foo();
                    Foo();
                }
            }

            void FooLocal()
            {
                if (_condition)
                {
                    Foo();

                    if (!_condition)
                    {
                        Foo();
                        Foo();
                    }
                }
            }
        }

        private static IEnumerable FooYield()
        {
            if (_condition)
            {
                yield return null;

                if (!_condition)
                {
                    yield return null;
                    yield return null;
                }
            }

            IEnumerable FooYieldLocal()
            {
                if (_condition)
                {
                    yield return null;

                    if (!_condition)
                    {
                        yield return null;
                        yield return null;
                    }
                }
            }
        }

        private static IEnumerable<object> FooYield2()
        {
            if (_condition)
            {
                yield return null;

                if (!_condition)
                {
                    yield return null;
                    yield return null;
                }
            }

            IEnumerable<object> FooYieldLocal()
            {
                if (_condition)
                {
                    yield return null;

                    if (!_condition)
                    {
                        yield return null;
                        yield return null;
                    }
                }
            }
        }

        private static async Task FooAsync()
        {
            if (_condition)
            {
                await FooAsync().ConfigureAwait(false);

                if (!_condition)
                {
                    Foo();
                    Foo();
                }
            }

            async Task FooLocalAsync()
            {
                if (_condition)
                {
                    await FooAsync().ConfigureAwait(false);

                    if (!_condition)
                    {
                        Foo();
                        Foo();
                    }
                }
            }
        }
    }
}
