﻿using System.Reflection;

namespace DepChecker
{
    public class DependencyChecker
    {
        private readonly ConstructorDependencyChecker _constructorDependencyChecker;
        private readonly FieldDependencyChecker _fieldDependencyChecker;

        public DependencyChecker(string happyZoneNamespace)
        {
            _constructorDependencyChecker = new ConstructorDependencyChecker(happyZoneNamespace);
            _fieldDependencyChecker = new FieldDependencyChecker(happyZoneNamespace);
        }

        public DependencyErrors Check(TypeInfo typeInHappyZone)
        {
            var errors = new DependencyErrors();

            errors.AddRange(_constructorDependencyChecker.Check(typeInHappyZone));
            errors.AddRange(_fieldDependencyChecker.Check(typeInHappyZone));

            return errors;
        }
    }
}